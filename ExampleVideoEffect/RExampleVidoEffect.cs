using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Graphics.DirectX.Direct3D11;
using Windows.Graphics.Imaging;
using Windows.Media.Effects;
using Windows.Media.MediaProperties;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ExampleVideoEffect
{

    public sealed class RExampleVidoEffect : IBasicVideoEffect
    {

        private static SoftwareBitmap Snap;
        public void SetEncodingProperties(VideoEncodingProperties encodingProperties, IDirect3DDevice device)
        {

        }

        public void ProcessFrame(ProcessVideoFrameContext context)
        {
            var inputFrameBitmap = context.InputFrame.SoftwareBitmap;
            Snap = inputFrameBitmap;
        }

        public static SoftwareBitmap GetSnapShot()
        {
            return Snap;
        }
        public void Close(MediaEffectClosedReason reason)
        {

        }

        public void DiscardQueuedFrames()
        {

        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public IReadOnlyList<VideoEncodingProperties> SupportedEncodingProperties
        {
            get { return new List<VideoEncodingProperties>(); }
        }
        public MediaMemoryTypes SupportedMemoryTypes
        {
            get { return MediaMemoryTypes.Cpu; }
        }

        public bool TimeIndependent
        {
            get { return true; }
        }



        public void SetProperties(IPropertySet configuration)
        {

        }
    }
}
            //// Create intermediate buffer for holding the frame pixel data.
            //var frameSize = inputFrameBitmap.PixelWidth * inputFrameBitmap.PixelHeight * 4;
            //var frameBuffer = new Windows.Storage.Streams.Buffer((uint)frameSize);
            //// Copy bitmap data from the input frame.
            //inputFrameBitmap.CopyToBuffer(frameBuffer);
            //// Iterate through all pixels in the frame.
            //var framePixels = frameBuffer.ToArray();
            //for (int i = 0; i < frameSize; i += 4)
            //{
            //    // Calculate the luminance based on the RGB values - this way we can convert it to grayscale.
            //    var bValue = framePixels[i];
            //    var gValue = framePixels[i + 1];
            //    var rValue = framePixels[i + 2];

            //    var luminance = ((rValue / 255.0f) * 0.2126f) +
            //                    ((gValue / 255.0f) * 0.7152f) +
            //                    ((bValue / 255.0f) * 0.0722f);

            //    // Set the pixel data to the calculated grayscale values.
            //    framePixels[i] = framePixels[i + 1] = framePixels[i + 2] = (byte)(luminance * 255.0f);
            //}
            // Copy the modified frame data to the output frame.
            //context.OutputFrame.SoftwareBitmap.CopyFromBuffer(framePixels.AsBuffer());
        //    private VideoEncodingProperties encodingProperties;
        //    private CanvasDevice canvasDevice;
        //    public void SetEncodingProperties(VideoEncodingProperties encodingProperties, IDirect3DDevice device)
        //    {
        //        this.encodingProperties = encodingProperties;
        //        this.canvasDevice = CanvasDevice.CreateFromDirect3D11Device(device);
        //    }
        //    public void ProcessFrame(ProcessVideoFrameContext context)
        //    {
        //        using (CanvasBitmap inputBitmap = CanvasBitmap.CreateFromDirect3D11Surface(canvasDevice, context.InputFrame.Direct3DSurface))
        //        using (CanvasRenderTarget renderTarget = CanvasRenderTarget.CreateFromDirect3D11Surface(canvasDevice, context.OutputFrame.Direct3DSurface))
        //        using (CanvasDrawingSession ds = renderTarget.CreateDrawingSession())
        //        {


        //            var gaussianBlurEffect = new GaussianBlurEffect
        //            {
        //                Source = inputBitmap,
        //                BlurAmount = (float)BlurAmount,
        //                Optimization = EffectOptimization.Speed
        //            };

        //            ds.DrawImage(gaussianBlurEffect);

        //        }
        //    }

        //    public void Close(MediaEffectClosedReason reason)
        //    {

        //    }

        //    public void DiscardQueuedFrames()
        //    {

        //    }

        //    public bool IsReadOnly
        //    {
        //        get { return true; }
        //    }

        //    public IReadOnlyList<VideoEncodingProperties> SupportedEncodingProperties
        //    {
        //        get
        //        {
        //            var encodingProperties = new VideoEncodingProperties();
        //            encodingProperties.Subtype = "ARGB32";
        //            return new List<VideoEncodingProperties>() { encodingProperties };
        //        }
        //    }

        //    public MediaMemoryTypes SupportedMemoryTypes
        //    {
        //        get
        //        {
        //            return MediaMemoryTypes.Gpu;
        //        }
        //    }

        //    public bool TimeIndependent
        //    {
        //        get
        //        {
        //            return true;
        //        }
        //    }

        //    private IPropertySet configuration;
        //    public void SetProperties(IPropertySet configuration)
        //    {
        //        this.configuration = configuration;
        //    }
        //    public double BlurAmount
        //    {
        //        get
        //        {
        //            object val;
        //            if (configuration != null && configuration.TryGetValue("BlurAmount", out val))
        //            {
        //                return (double)val;

        //            }
        //            return 3;
        //        }
        //    }
        //    public double FadeValue
        //    {
        //        get
        //        {
        //            object val;
        //            if (configuration != null && configuration.TryGetValue("FadeValue", out val))
        //            {
        //                return (double)val;
        //            }
        //            return 0.5;
        //        }
        //    }

        //    public unsafe void ProcessFrame(ProcessVideoFrameContext context)
        //    {
        //        using (BitmapBuffer buffer = context.InputFrame.SoftwareBitmap.LockBuffer(BitmapBufferAccessMode.Read))
        //        using (BitmapBuffer targetBuffer = context.OutputFrame.SoftwareBitmap.LockBuffer(BitmapBufferAccessMode.Write))
        //        {
        //            using (var reference = buffer.CreateReference())
        //            using (var targetReference = targetBuffer.CreateReference())
        //            {
        //                byte* dataInBytes;
        //                uint capacity;
        //                ((IMemoryBufferByteAccess)reference).GetBuffer(out dataInBytes, out capacity);

        //                byte* targetDataInBytes;
        //                uint targetCapacity;
        //                ((IMemoryBufferByteAccess)targetReference).GetBuffer(out targetDataInBytes, out targetCapacity);

        //                var fadeValue = FadeValue;

        //                // Fill-in the BGRA plane
        //                BitmapPlaneDescription bufferLayout = buffer.GetPlaneDescription(0);
        //                for (int i = 0; i < bufferLayout.Height; i++)
        //                {
        //                    for (int j = 0; j < bufferLayout.Width; j++)
        //                    {

        //                        byte value = (byte)((float)j / bufferLayout.Width * 255);

        //                        int bytesPerPixel = 4;
        //                        if (encodingProperties.Subtype != "ARGB32")
        //                        {
        //                            // If you support other encodings, adjust index into the buffer accordingly
        //                        }


        //                        int idx = bufferLayout.StartIndex + bufferLayout.Stride * i + bytesPerPixel * j;

        //                        targetDataInBytes[idx + 0] = (byte)(fadeValue * (float)dataInBytes[idx + 0]);
        //                        targetDataInBytes[idx + 1] = (byte)(fadeValue * (float)dataInBytes[idx + 1]);
        //                        targetDataInBytes[idx + 2] = (byte)(fadeValue * (float)dataInBytes[idx + 2]);
        //                        targetDataInBytes[idx + 3] = dataInBytes[idx + 3];
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //[ComImport]
        //[Guid("5B0D3235-4DBA-4D44-865E-8F1D0E4FD04D")]
        //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        //unsafe interface IMemoryBufferByteAccess
        //{
        //    void GetBuffer(out byte* buffer, out uint capacity);
        //}
    
