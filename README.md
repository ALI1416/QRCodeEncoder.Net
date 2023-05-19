# QRCodeEncoder.Net 二维码生成器.Net版

[![License](https://img.shields.io/github/license/ali1416/QRCodeEncoder.Net?label=License)](https://www.apache.org/licenses/LICENSE-2.0.txt)
[![.Net Support](https://img.shields.io/badge/.NET%20Standard-2.0+-green)](https://openjdk.org/)
[![NuGet Gallery](https://img.shields.io/nuget/v/Z.QRCodeEncoder.Net?label=NuGet%20Gallery)](https://www.nuget.org/packages/Z.QRCodeEncoder.Net)
[![Tag](https://img.shields.io/github/v/tag/ali1416/QRCodeEncoder.Net?label=Tag)](https://github.com/ALI1416/QRCodeEncoder.Net/tags)
[![Repo Size](https://img.shields.io/github/repo-size/ali1416/QRCodeEncoder.Net?label=Repo%20Size&color=success)](https://github.com/ALI1416/QRCodeEncoder.Net/archive/refs/heads/master.zip)

[![DotNet CI](https://github.com/ALI1416/QRCodeEncoder.Net/actions/workflows/ci.yml/badge.svg)](https://github.com/ALI1416/QRCodeEncoder.Net/actions/workflows/ci.yml)

## 简介

本项目参考了[micjahn/ZXing.Net](https://github.com/micjahn/ZXing.Net)，只编写了生成器部分，并对处理逻辑进行了大量优化，编译后dll文件仅40kb

注意：本项目不提供二维码绘制方法，如需绘制请看`使用示例`

## 依赖导入

```bat
dotnet add package Z.QRCodeEncoder.Net --version 1.0.1
```

## 方法和参数

### 二维码 QRCode

| 参数名        | 中文名   | 类型   | 默认值     |
| ------------- | -------- | ------ | ---------- |
| content       | 内容     | string | (无)       |
| level         | 纠错等级 | int    | 0          |
| mode          | 编码模式 | int    | (自动探测) |
| versionNumber | 版本号   | int    | (最小版本) |

### 版本 Version

| 参数名        | 中文名     | 类型 | 默认值     |
| ------------- | ---------- | ---- | ---------- |
| length        | 内容字节数 | int  | (无)       |
| level         | 纠错等级   | int  | (无)       |
| mode          | 编码模式   | int  | (无)       |
| versionNumber | 版本号     | int  | (最小版本) |

### 掩模模板 MaskPattern

| 参数名  | 中文名   | 类型    |
| ------- | -------- | ------- |
| data    | 数据     | bool[]  |
| version | 版本     | Version |
| level   | 纠错等级 | int     |

### 纠错等级 level

| 值  | 等级 | 纠错率 |
| --- | ---- | ------ |
| 0   | L    | 7%     |
| 1   | M    | 15%    |
| 2   | Q    | 25%    |
| 3   | H    | 30%    |

### 编码模式 mode

| 值  | 模式             | 备注                                     |
| --- | ---------------- | ---------------------------------------- |
| 0   | NUMERIC          | 数字0-9                                  |
| 1   | ALPHANUMERIC     | 数字0-9、大写字母A-Z、符号(空格)$%*+-./: |
| 2   | BYTE(ISO-8859-1) | 兼容ASCII                                |
| 3   | BYTE(UTF-8)      |                                          |

### 版本号 versionNumber

取值范围：`[1,40]`

## 使用示例

### 生成并绘制二维码

Program.cs

```csharp
string content = "1234😀";
int level = 0;
QRCode qrCode = new QRCode(content, level);
Bitmap bitmap = ImageUtils.QrBytes2Bitmap(qrCode.Matrix, 10);
ImageUtils.SaveBitmap(bitmap, "qr.png");
```

ImageUtils.cs

```csharp
private static readonly Brush BLACK_BRUSH = new SolidBrush(Color.Black);

public static Bitmap QrBytes2Bitmap(bool[,] bytes, int pixelSize)
{
    int length = bytes.GetLength(0);
    List<Rectangle> rects = new List<Rectangle>();
    for (int x = 0; x < length; x++)
    {
        for (int y = 0; y < length; y++)
        {
            if (bytes[x, y])
            {
                rects.Add(new Rectangle((x + 1) * pixelSize, (y + 1) * pixelSize, pixelSize, pixelSize));
            }
        }
    }
    int size = (length + 2) * pixelSize;
    Bitmap bitmap = new Bitmap(size, size);
    using (Graphics g = Graphics.FromImage(bitmap))
    {
        g.FillRectangles(BLACK_BRUSH, rects.ToArray());
    }
    return bitmap;
}

public static void SaveBitmap(Bitmap bitmap, string path)
{
    bitmap.Save(path, ImageFormat.Png);
}
```

## 更新日志

[点击查看](./CHANGELOG.md)

## 参考

- [micjahn/ZXing.Net](https://github.com/micjahn/ZXing.Net)

## 交流与赞助

- [x] `QQ` : `1416978277`
- [x] `微信` : `1416978277`
- [x] `支付宝` : `1416978277@qq.com`
- [x] `电子邮箱` : `1416978277@qq.com`

![交流](https://cdn.jsdelivr.net/gh/ALI1416/ALI1416/image/contact.png)

![赞助](https://cdn.jsdelivr.net/gh/ALI1416/ALI1416/image/donate.png)
