using System;
using OpenCvSharp;

namespace FaceDetectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Eğitilmiş Haar Cascade modelini yükleyin
            string cascadePath = "haarcascade_frontalface_default.xml";
            using var faceCascade = new CascadeClassifier(cascadePath);

            // 2. Kamerayı başlatın ('0' bilgisayarın varsayılan web kamerasını temsil eder)
            using var capture = new VideoCapture(0);

            if (!capture.IsOpened())
            {
                Console.WriteLine("Kamera açılamadı! Lütfen bağlantıyı veya izinleri kontrol edin.");
                return;
            }

            Console.WriteLine("Kamera açıldı. Kapatmak için 'ESC' tuşuna basın.");

            // Pencereyi ve hafızada tutulacak resim karelerini (Mat) önceden oluşturun
            using var window = new Window("Canlı Yüz Tespiti");
            using var frame = new Mat();
            using var grayImage = new Mat();

            // 3. Kameradan sürekli görüntü almak için sonsuz döngü başlatın
            while (true)
            {
                // Kameradan anlık kareyi (frame) oku
                capture.Read(frame);

                // Eğer okunan kare boşsa döngüyü kır
                if (frame.Empty())
                    break;

                // Resmi gri tonlamaya çevir (Performans ve doğruluk için)
                Cv2.CvtColor(frame, grayImage, ColorConversionCodes.BGR2GRAY);

                // Yüzleri tespit et
                Rect[] faces = faceCascade.DetectMultiScale(
                    image: grayImage,
                    scaleFactor: 1.1,
                    minNeighbors: 5,
                    minSize: new Size(30, 30)
                );

                // Tespit edilen yüzlerin etrafına dikdörtgen çiz (Bu sefer yeşil renk)
                foreach (var face in faces)
                {
                    Cv2.Rectangle(frame, face, Scalar.Green, 2);
                }

                // İşlenmiş görüntüyü ekranda göster
                window.ShowImage(frame);

                // 4. Çıkış kontrolü
                // Her karede 1 milisaniye boyunca klavyeden bir tuşa basılmasını bekle
                // '27', klavyedeki 'ESC' tuşunun ASCII kodudur.
                int key = Cv2.WaitKey(1);
                if (key == 27)
                {
                    break;
                }
            }
        }
    }
}