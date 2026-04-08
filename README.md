# Real-Time Face Detection with C# and OpenCV

This project is a C# console application that performs real-time face detection using your computer's webcam via the **OpenCvSharp** library. It utilizes the pre-trained **Haar Cascade** model for image processing and face recognition.

## 🚀 Features
* Real-time video streaming from the webcam.
* Optimized performance by converting frames to grayscale.
* Instant face detection using the Haar Cascade algorithm.
* Live drawing of bounding boxes (green rectangles) around detected faces.

## 📋 Requirements

To run this project on your machine, you will need:
* **Visual Studio** (2019 or newer is recommended)
* **.NET SDK** (.NET Core 3.1, .NET 5, 6, 7, or 8)
* A working webcam.

## 🛠️ Installation Steps

1. **Create the Project:**
   Create a new C# Console Application (.NET) project in Visual Studio.

2. **Install Required NuGet Packages:**
   To add OpenCV capabilities to your project, install the following packages via the NuGet Package Manager (or Package Manager Console):
   ```bash
   Install-Package OpenCvSharp4
   Install-Package OpenCvSharp4.runtime.win
