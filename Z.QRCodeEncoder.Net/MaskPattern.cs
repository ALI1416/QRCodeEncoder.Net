﻿using System;

namespace Z.QRCodeEncoder.Net
{

    /// <summary>
    /// 掩模模板
    /// </summary>
    public class MaskPattern
    {

        /// <summary>
        /// 模板列表
        /// <para>0白 1黑</para>
        /// </summary>
        public readonly byte[][,] Patterns = new byte[8][,];
        /// <summary>
        /// 惩戒分列表
        /// </summary>
        public readonly int[] Penalties = new int[8];
        /// <summary>
        /// 最好的模板下标
        /// </summary>
        public readonly int Best;

        /// <summary>
        /// 格式信息
        /// </summary>
        private static readonly bool[,][] FormatInfo = new bool[4, 8][];
        /// <summary>
        /// 版本信息(版本7+)
        /// </summary>
        private static readonly bool[][] VersionInfo = new bool[34][];

        static MaskPattern()
        {
            // 初始化格式信息
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    FormatInfo[i, j] = QRCodeUtils.GetBits(FORMAT_INFO[i, j], 15);
                }
            }
            // 初始化版本信息(版本7+)
            for (int i = 0; i < 34; i++)
            {
                VersionInfo[i] = QRCodeUtils.GetBits(VERSION_INFO[i], 18);
            }
        }

        /// <summary>
        /// 构建模板
        /// </summary>
        /// <param name="data">
        /// 数据
        /// </param>
        /// <param name="version">
        /// 版本
        /// </param>
        /// <param name="level">
        /// 纠错等级
        /// <para>0 L 7%</para>
        /// <para>1 M 15%</para>
        /// <para>2 Q 25%</para>
        /// <para>3 H 30%</para>
        /// </param>
        public MaskPattern(bool[] data, Version version, int level)
        {
            int dimension = version.Dimension;
            int versionNumber = version.VersionNumber;
            for (int i = 0; i < 8; i++)
            {
                // 新建模板 0白 1黑 2空
                byte[,] pattern = new byte[dimension, dimension];
                // 填充为空模板
                FillEmptyPattern(pattern, dimension);
                // 嵌入基础图形
                EmbedBasicPattern(pattern, dimension, versionNumber);
                // 嵌入格式信息
                EmbedFormatInfo(pattern, dimension, level, i);
                // 嵌入版本信息(版本7+)
                EmbedVersionInfo(pattern, dimension, versionNumber);
                // 嵌入数据
                EmbedData(pattern, dimension, i, data);
                Patterns[i] = pattern;
                // 计算惩戒分
                Penalties[i] = MaskPenaltyRule(pattern, dimension);
            }
            // 找到最好的模板
            int minPenalty = int.MaxValue;
            Best = -1;
            for (int i = 0; i < 8; i++)
            {
                if (Penalties[i] < minPenalty)
                {
                    minPenalty = Penalties[i];
                    Best = i;
                }
            }
        }

        /// <summary>
        /// 填充为空模板
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        private static void FillEmptyPattern(byte[,] pattern, int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    pattern[i, j] = 2;
                }
            }
        }

        /// <summary>
        /// 嵌入基础图形
        /// <para>包含：</para>
        /// <para>位置探测图形和分隔符</para>
        /// <para>位置校正图形(版本2+)</para>
        /// <para>定位图形</para>
        /// <para>左下角黑点</para>
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        /// <param name="versionNumber">版本号</param>
        private static void EmbedBasicPattern(byte[,] pattern, int dimension, int versionNumber)
        {
            // 嵌入位置探测和分隔符图形
            EmbedPositionFinderPatternAndSeparator(pattern, dimension);
            // 嵌入位置校正图形(版本2+)
            EmbedPositionAlignmentPattern(pattern, versionNumber);
            // 嵌入定位图形
            EmbedTimingPattern(pattern, dimension);
            // 嵌入左下角黑点
            EmbedDarkDotAtLeftBottomCorner(pattern, dimension);
        }

        /// <summary>
        /// 嵌入位置探测和分隔符图形
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        private static void EmbedPositionFinderPatternAndSeparator(byte[,] pattern, int dimension)
        {
            /* 嵌入位置探测图形 */
            int finderDimension = 7;
            // 左上角
            EmbedPositionFinderPattern(pattern, 0, 0);
            // 右上角
            EmbedPositionFinderPattern(pattern, dimension - finderDimension, 0);
            // 左下角
            EmbedPositionFinderPattern(pattern, 0, dimension - finderDimension);

            /* 嵌入水平分隔符图形 */
            int horizontalWidth = 8;
            // 左上角
            EmbedHorizontalSeparationPattern(pattern, 0, horizontalWidth - 1);
            // 右上角
            EmbedHorizontalSeparationPattern(pattern, dimension - horizontalWidth, horizontalWidth - 1);
            // 左下角
            EmbedHorizontalSeparationPattern(pattern, 0, dimension - horizontalWidth);

            /* 嵌入垂直分隔符图形 */
            int verticalHeight = 7;
            // 左上角
            EmbedVerticalSeparationPattern(pattern, verticalHeight, 0);
            // 右上角
            EmbedVerticalSeparationPattern(pattern, dimension - verticalHeight - 1, 0);
            // 左下角
            EmbedVerticalSeparationPattern(pattern, verticalHeight, dimension - verticalHeight);
        }

        /// <summary>
        /// 嵌入位置探测图形
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="xStart">x起始坐标</param>
        /// <param name="yStart">y起始坐标</param>
        private static void EmbedPositionFinderPattern(byte[,] pattern, int xStart, int yStart)
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    pattern[xStart + x, yStart + y] = POSITION_FINDER_PATTERN[x, y];
                }
            }
        }

        /// <summary>
        /// 嵌入水平分隔符图形
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="xStart">x起始坐标</param>
        /// <param name="yStart">y起始坐标</param>
        private static void EmbedHorizontalSeparationPattern(byte[,] pattern, int xStart, int yStart)
        {
            for (int x = 0; x < 8; x++)
            {
                pattern[xStart + x, yStart] = 0;
            }
        }

        /// <summary>
        /// 嵌入垂直分隔符图形
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="xStart">x起始坐标</param>
        /// <param name="yStart">y起始坐标</param>
        private static void EmbedVerticalSeparationPattern(byte[,] pattern, int xStart, int yStart)
        {
            for (int y = 0; y < 7; y++)
            {
                pattern[xStart, yStart + y] = 0;
            }
        }

        /// <summary>
        /// 嵌入左下角黑点
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        private static void EmbedDarkDotAtLeftBottomCorner(byte[,] pattern, int dimension)
        {
            pattern[8, dimension - 8] = 1;
        }

        /// <summary>
        /// 嵌入位置校正图形(版本2+)
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="versionNumber">版本号</param>
        private static void EmbedPositionAlignmentPattern(byte[,] pattern, int versionNumber)
        {
            if (versionNumber < 2)
            {
                return;
            }
            int[] coordinates = POSITION_ALIGNMENT_PATTERN_COORDINATE[versionNumber - 2];
            int length = coordinates.Length;
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    // 跳过位置探测图形
                    if ((x == 0 && y == 0) || (x == 0 && y == length - 1) || (y == 0 && x == length - 1))
                    {
                        continue;
                    }
                    EmbedPositionAlignmentPattern(pattern, coordinates[x] - 2, coordinates[y] - 2);
                }
            }
        }

        /// <summary>
        /// 嵌入位置校正图形
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="xStart">x起始坐标</param>
        /// <param name="yStart">y起始坐标</param>
        private static void EmbedPositionAlignmentPattern(byte[,] pattern, int xStart, int yStart)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    pattern[xStart + x, yStart + y] = POSITION_ALIGNMENT_PATTERN[x, y];
                }
            }
        }

        /// <summary>
        /// 嵌入定位图形
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        private static void EmbedTimingPattern(byte[,] pattern, int dimension)
        {
            for (int i = 8; i < dimension - 8; i++)
            {
                byte isBlack = (byte)((i + 1) % 2);
                // 不必跳过校正图形
                pattern[i, 6] = isBlack;
                pattern[6, i] = isBlack;
            }
        }

        /// <summary>
        /// 嵌入格式信息
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        /// <param name="level">纠错等级</param>
        /// <param name="id">模板序号</param>
        private static void EmbedFormatInfo(byte[,] pattern, int dimension, int level, int id)
        {
            bool[] formatInfo = FormatInfo[level, id];
            for (int i = 0; i < 15; i++)
            {
                byte isBlack = (byte)(formatInfo[14 - i] ? 1 : 0);
                // 左上角
                pattern[FORMAT_INFO_COORDINATES[i, 0], FORMAT_INFO_COORDINATES[i, 1]] = isBlack;
                int x, y;
                // 右上角
                if (i < 8)
                {
                    x = dimension - i - 1;
                    y = 8;
                }
                // 左下角
                else
                {
                    x = 8;
                    y = dimension + i - 15;
                }
                pattern[x, y] = isBlack;
            }
        }

        /// <summary>
        /// 嵌入版本信息(版本7+)
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="dimension">尺寸</param>
        /// <param name="versionNumber">版本号</param>
        private static void EmbedVersionInfo(byte[,] pattern, int dimension, int versionNumber)
        {
            if (versionNumber < 7)
            {
                return;
            }
            bool[] versionInfo = VersionInfo[versionNumber - 7];
            int index = 17;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    byte isBlack = (byte)(versionInfo[index--] ? 1 : 0);
                    // 左下角
                    pattern[i, dimension - 11 + j] = isBlack;
                    // 右上角
                    pattern[dimension - 11 + j, i] = isBlack;
                }
            }
        }

        /// <summary>
        /// 嵌入数据
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        /// <param name="id">模板序号</param>
        /// <param name="data">数据</param>
        private static void EmbedData(byte[,] pattern, int dimension, int id, bool[] data)
        {
            int length = data.Length;
            int index = 0;
            int direction = -1;
            // 从右下角开始
            int x = dimension - 1;
            int y = dimension - 1;
            while (x > 0)
            {
                // 跳过垂直分隔符图形
                if (x == 6)
                {
                    x -= 1;
                }
                while (y >= 0 && y < dimension)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int xx = x - i;
                        // 跳过不为空
                        if (pattern[xx, y] != 2)
                        {
                            continue;
                        }
                        int isBlack;
                        if (index < length)
                        {
                            isBlack = data[index] ? 1 : 0;
                            index++;
                        }
                        else
                        {
                            isBlack = 0;
                        }
                        // 需要掩模
                        if (GetMaskBit(id, xx, y))
                        {
                            isBlack ^= 1;
                        }
                        pattern[xx, y] = (byte)isBlack;
                    }
                    y += direction;
                }
                direction = -direction;
                y += direction;
                x -= 2;
            }
        }

        /// <summary>
        /// 获取指定坐标是否需要掩模
        /// </summary>
        /// <param name="id">模板序号</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <returns>是否需要掩模</returns>
        public static bool GetMaskBit(int id, int x, int y)
        {
            switch (id)
            {
                default:
                case 0:
                    {
                        return ((x + y) % 2) == 0;
                    }
                case 1:
                    {
                        return (y % 2) == 0;
                    }
                case 2:
                    {
                        return (x % 3) == 0;
                    }
                case 3:
                    {
                        return ((x + y) % 3) == 0;
                    }
                case 4:
                    {
                        return (((y / 2) + (x / 3)) % 2) == 0;
                    }
                case 5:
                    {
                        int temp = x * y;
                        return ((temp % 2) + (temp % 3)) == 0;
                    }
                case 6:
                    {
                        int temp = x * y;
                        return (((temp % 2) + (temp % 3)) % 2) == 0;
                    }
                case 7:
                    {
                        return ((((x * y) % 3) + ((x + y) % 2)) % 2) == 0;
                    }
            }
        }

        /// <summary>
        /// 掩模惩戒规则
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        /// <returns>惩戒分</returns>
        private static int MaskPenaltyRule(byte[,] pattern, int dimension)
        {
            return MaskPenaltyRule1(pattern, dimension)
                + MaskPenaltyRule2(pattern, dimension)
                + MaskPenaltyRule3(pattern, dimension)
                + MaskPenaltyRule4(pattern, dimension);
        }

        /// <summary>
        /// 掩模惩戒规则1
        /// <para>行或列，连续颜色相同(不可重复计算)</para>
        /// <para>惩戒分=PENALTY1+(个数-5)</para>
        /// <para>惩戒分在个数>=5时生效</para>
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        /// <returns>规则1惩戒分</returns>
        private static int MaskPenaltyRule1(byte[,] pattern, int dimension)
        {
            int penalty = 0;
            for (int i = 0; i < dimension; i++)
            {
                int countRow = 0;
                int countCol = 0;
                byte prevBitRow = 2;
                byte prevBitCol = 2;
                for (int j = 0; j < dimension; j++)
                {
                    byte bitRow = pattern[i, j];
                    byte bitCol = pattern[j, i];
                    // 行
                    if (bitRow == prevBitRow)
                    {
                        countRow++;
                    }
                    else
                    {
                        if (countRow > 4)
                        {
                            penalty += PENALTY1 + (countRow - 5);
                        }
                        countRow = 1;
                        prevBitRow = bitRow;
                    }
                    // 列
                    if (bitCol == prevBitCol)
                    {
                        countCol++;
                    }
                    else
                    {
                        if (countCol > 4)
                        {
                            penalty += PENALTY1 + (countCol - 5);
                        }
                        countCol = 1;
                        prevBitCol = bitCol;
                    }
                }
                // 行
                if (countRow > 4)
                {
                    penalty += PENALTY1 + (countRow - 5);
                }
                // 列
                if (countCol > 4)
                {
                    penalty += PENALTY1 + (countCol - 5);
                }
            }
            return penalty;
        }

        /// <summary>
        /// 掩模惩戒规则2
        /// <para>2x2，块内颜色相同(重复计算)</para>
        /// <para>惩戒分=PENALTY2*出现次数</para>
        /// <para>惩戒分在出现次数>=1时生效</para>
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        /// <returns>规则2惩戒分</returns>
        private static int MaskPenaltyRule2(byte[,] pattern, int dimension)
        {
            int penalty = 0;
            for (int x = 0; x < dimension - 1; x++)
            {
                for (int y = 0; y < dimension - 1; y++)
                {
                    // 2x2块
                    byte bit = pattern[x, y];
                    if (bit == pattern[x, y + 1] && bit == pattern[x + 1, y] && bit == pattern[x + 1, y + 1])
                    {
                        penalty++;
                    }
                }
            }
            return PENALTY2 * penalty;
        }

        /// <summary>
        /// 掩模惩戒规则3
        /// <para>行或列，出现[黑,白,黑黑黑,白,黑]序列，并且前或后有4个白色</para>
        /// <para>惩戒分=PENALTY3*出现次数</para>
        /// <para>惩戒分在出现次数>=1时生效</para>
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        /// <returns>规则3惩戒分</returns>
        private static int MaskPenaltyRule3(byte[,] pattern, int dimension)
        {
            int penalty = 0;
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    // 行
                    if (
                        // 列区间[0, dimension - 6)
                        y < dimension - 6 &&
                        // [黑,白,黑黑黑,白,黑]序列
                        pattern[x, y] == 1 &&
                        pattern[x, y + 1] == 0 &&
                        pattern[x, y + 2] == 1 &&
                        pattern[x, y + 3] == 1 &&
                        pattern[x, y + 4] == 1 &&
                        pattern[x, y + 5] == 0 &&
                        pattern[x, y + 6] == 1 &&
                        // 左或右有4个白色
                        (
                            // 左有4个白色
                            (
                                // 列区间[4,)
                                y > 3 &&
                                // [白白白白]序列
                                pattern[x, y - 1] == 0 &&
                                pattern[x, y - 2] == 0 &&
                                pattern[x, y - 3] == 0 &&
                                pattern[x, y - 4] == 0) ||
                            // 右有4个白色
                            (
                                // 列区间[0, dimension - 10)
                                y < dimension - 10 &&
                                // [白白白白]序列
                                pattern[x, y + 7] == 0 &&
                                pattern[x, y + 8] == 0 &&
                                pattern[x, y + 9] == 0 &&
                                pattern[x, y + 10] == 0)))
                    {
                        penalty++;
                    }
                    // 列
                    if (
                        // 行区间[0, dimension - 6)
                        x < dimension - 6 &&
                        // [黑,白,黑黑黑,白,黑]序列
                        pattern[x, y] == 1 &&
                        pattern[x + 1, y] == 0 &&
                        pattern[x + 2, y] == 1 &&
                        pattern[x + 3, y] == 1 &&
                        pattern[x + 4, y] == 1 &&
                        pattern[x + 5, y] == 0 &&
                        pattern[x + 6, y] == 1 &&
                        // 上或下有4个白色
                        (
                            // 上有4个白色
                            (
                                // 行区间[4,)
                                x > 3 &&
                                // [白白白白]序列
                                pattern[x - 1, y] == 0 &&
                                pattern[x - 2, y] == 0 &&
                                pattern[x - 3, y] == 0 &&
                                pattern[x - 4, y] == 0) ||
                            // 下有4个白色
                            (
                                // 行区间[0, dimension - 10)
                                x < dimension - 10 &&
                                // [白白白白]序列
                                pattern[x + 7, y] == 0 &&
                                pattern[x + 8, y] == 0 &&
                                pattern[x + 9, y] == 0 &&
                                pattern[x + 10, y] == 0)))
                    {
                        penalty++;
                    }
                }
            }
            return PENALTY3 * penalty;
        }

        /// <summary>
        /// 掩模惩戒规则4
        /// <para>颜色占比</para>
        /// <para>惩戒分=PENALTY4*((黑色占比-0.5)的绝对值*20)</para>
        /// <para>惩戒分始终生效</para>
        /// </summary>
        /// <param name="pattern">模板</param>
        /// <param name="dimension">尺寸</param>
        /// <returns>规则4惩戒分</returns>
        private static int MaskPenaltyRule4(byte[,] pattern, int dimension)
        {
            int count = 0;
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    if (pattern[x, y] == 1)
                    {
                        count++;
                    }
                }
            }
            double ratio = (double)count / (dimension * dimension);
            int penalty = (int)(Math.Abs(ratio - 0.5) * 20);
            return PENALTY4 * penalty;
        }

        /// <summary>
        /// 位置探测图形
        /// <para>索引[x坐标,y坐标]:7x7</para>
        /// <para>数量:3个(左上角、右上角、左下角)</para>
        /// <para>数据来源 ISO/IEC 18004-2015 -> 6.3.3.1</para>
        /// </summary>
        private static readonly byte[,] POSITION_FINDER_PATTERN =
        {
            {1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 0, 1},
            {1, 0, 1, 1, 1, 0, 1},
            {1, 0, 1, 1, 1, 0, 1},
            {1, 0, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1},
        };

        /// <summary>
        /// 位置校正图形
        /// <para>索引[x坐标,y坐标]:5x5</para>
        /// <para>数量:根据版本号而定</para>
        /// <para>数据来源 ISO/IEC 18004-2015 -> 6.3.6</para>
        /// </summary>
        private static readonly byte[,] POSITION_ALIGNMENT_PATTERN =
        {
            {1, 1, 1, 1, 1},
            {1, 0, 0, 0, 1},
            {1, 0, 1, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 1, 1, 1, 1},
        };

        /// <summary>
        /// 位置校正图形坐标(版本2+)
        /// <para>索引[版本号][坐标]:39x?</para>
        /// <para>数据来源 ISO/IEC 18004-2015 -> Annex E -> Table E.1</para>
        /// </summary>
        private static readonly int[][] POSITION_ALIGNMENT_PATTERN_COORDINATE =
        {
             new int[] {6, 18},
             new int[] {6, 22},
             new int[] {6, 26},
             new int[] {6, 30},
             new int[] {6, 34},
             new int[] {6, 22, 38},
             new int[] {6, 24, 42},
             new int[] {6, 26, 46},
             new int[] {6, 28, 50},
             new int[] {6, 30, 54},
             new int[] {6, 32, 58},
             new int[] {6, 34, 62},
             new int[] {6, 26, 46, 66},
             new int[] {6, 26, 48, 70},
             new int[] {6, 26, 50, 74},
             new int[] {6, 30, 54, 78},
             new int[] {6, 30, 56, 82},
             new int[] {6, 30, 58, 86},
             new int[] {6, 34, 62, 90},
             new int[] {6, 28, 50, 72,  94},
             new int[] {6, 26, 50, 74,  98},
             new int[] {6, 30, 54, 78, 102},
             new int[] {6, 28, 54, 80, 106},
             new int[] {6, 32, 58, 84, 110},
             new int[] {6, 30, 58, 86, 114},
             new int[] {6, 34, 62, 90, 118},
             new int[] {6, 26, 50, 74,  98, 122},
             new int[] {6, 30, 54, 78, 102, 126},
             new int[] {6, 26, 52, 78, 104, 130},
             new int[] {6, 30, 56, 82, 108, 134},
             new int[] {6, 34, 60, 86, 112, 138},
             new int[] {6, 30, 58, 86, 114, 142},
             new int[] {6, 34, 62, 90, 118, 146},
             new int[] {6, 30, 54, 78, 102, 126, 150},
             new int[] {6, 24, 50, 76, 102, 128, 154},
             new int[] {6, 28, 54, 80, 106, 132, 158},
             new int[] {6, 32, 58, 84, 110, 136, 162},
             new int[] {6, 26, 54, 82, 110, 138, 166},
             new int[] {6, 30, 58, 86, 114, 142, 170},
        };

        /// <summary>
        /// 格式信息坐标(左上角)
        /// <para>索引[x坐标,y坐标]:15x2</para>
        /// <para>数据来源 ISO/IEC 18004-2015 -> 7.9.1 -> Figure 25</para>
        /// </summary>
        private static readonly int[,] FORMAT_INFO_COORDINATES =
        {
            {8, 0},
            {8, 1},
            {8, 2},
            {8, 3},
            {8, 4},
            {8, 5},
            {8, 7},
            {8, 8},
            {7, 8},
            {5, 8},
            {4, 8},
            {3, 8},
            {2, 8},
            {1, 8},
            {0, 8},
        };

        /// <summary>
        /// 格式信息
        /// <para>索引[纠错等级,模板序号]:4x8</para>
        /// <para>数据来源 ISO/IEC 18004-2015 -> Annex C -> Table C.1 -> Sequence after masking (QR Code symbols) -> hex列</para>
        /// </summary>
        private static readonly int[,] FORMAT_INFO = new int[,]
        {
            { 0x77C4, 0x72F3, 0x7DAA, 0x789D, 0x662F, 0x6318, 0x6C41, 0x6976, }, // 0
            { 0x5412, 0x5125, 0x5E7C, 0x5B4B, 0x45F9, 0x40CE, 0x4F97, 0x4AA0, }, // 1
            { 0x355F, 0x3068, 0x3F31, 0x3A06, 0x24B4, 0x2183, 0x2EDA, 0x2BED, }, // 2
            { 0x1689, 0x13BE, 0x1CE7, 0x19D0, 0x0762, 0x0255, 0x0D0C, 0x083B, }, // 3
        };

        /// <summary>
        /// 版本信息(版本7+)
        /// <para>索引[版本号]:34</para>
        /// <para>数据来源 ISO/IEC 18004-2015 -> Annex D -> Table D.1 -> Hex equivalent列</para>
        /// </summary>
        private static readonly int[] VERSION_INFO = new int[]
        {
                     0x07C94, 0x085BC, 0x09A99, 0x0A4D3, // 7-10
            0x0BBF6, 0x0C762, 0x0D847, 0x0E60D, 0x0F928, // 11-15
            0x10B78, 0x1145D, 0x12A17, 0x13532, 0x149A6, // 16-20
            0x15683, 0x168C9, 0x177EC, 0x18EC4, 0x191E1, // 21-25
            0x1AFAB, 0x1B08E, 0x1CC1A, 0x1D33F, 0x1ED75, // 26-30
            0x1F250, 0x209D5, 0x216F0, 0x228BA, 0x2379F, // 31-35
            0x24B0B, 0x2542E, 0x26A64, 0x27541, 0x28C69, // 36-40
        };

        /// <summary>
        /// 惩戒规则1惩戒分 3
        /// <para>数据来源 ISO/IEC 18004-2015 -> 7.8.3.1 -> N1</para>
        /// </summary>
        private static readonly int PENALTY1 = 3;
        /// <summary>
        /// 惩戒规则2惩戒分 3
        /// <para>数据来源 ISO/IEC 18004-2015 -> 7.8.3.1 -> N2</para>
        /// </summary>
        private static readonly int PENALTY2 = 3;
        /// <summary>
        /// 惩戒规则3惩戒分 40
        /// <para>数据来源 ISO/IEC 18004-2015 -> 7.8.3.1 -> N3</para>
        /// </summary>
        private static readonly int PENALTY3 = 40;
        /// <summary>
        /// 惩戒规则4惩戒分 10
        /// <para>数据来源 ISO/IEC 18004-2015 -> 7.8.3.1 -> N4</para>
        /// </summary>
        private static readonly int PENALTY4 = 10;

    }
}
