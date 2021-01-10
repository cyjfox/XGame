using System;
using System.IO;
using System.Text;

namespace XGame
{
	public class WavFile
	{
        private WavFile()
        {
        }

        public static Stream GenerateWavFileStream(UInt32 bitDepth, UInt32 totalSampleCount, Boolean isFloatingPoint,ushort channelCount, UInt32 sampleRate, Byte[] data)
        {
			Stream stream = new MemoryStream();
			stream.Position = 0;


            // RIFF header.
            // Chunk ID.
            stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);

            UInt32 dataSize = (bitDepth / 8) * totalSampleCount * channelCount; ;

            // Chunk size.
            stream.Write(BitConverter.GetBytes(dataSize + 36), 0, 4);

            // Format.
            stream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);



            // Sub-chunk 1.
            // Sub-chunk 1 ID.
            stream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);

            // Sub-chunk 1 size.
            stream.Write(BitConverter.GetBytes(16), 0, 4);

            // Audio format (floating point (3) or PCM (1)). Any other format indicates compression.
            stream.Write(BitConverter.GetBytes((ushort)(isFloatingPoint ? 3 : 1)), 0, 2);

            // Channels.
            stream.Write(BitConverter.GetBytes(channelCount), 0, 2);

            // Sample rate.
            stream.Write(BitConverter.GetBytes(sampleRate), 0, 4);

            // Bytes rate.
            stream.Write(BitConverter.GetBytes(sampleRate * channelCount * (bitDepth / 8)), 0, 4);

            // Block align.
            stream.Write(BitConverter.GetBytes((ushort)channelCount * (bitDepth / 8)), 0, 2);

            // Bits per sample.
            stream.Write(BitConverter.GetBytes(bitDepth), 0, 2);



            // Sub-chunk 2.
            // Sub-chunk 2 ID.
            stream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);

            // Sub-chunk 2 size.
            
            stream.Write(BitConverter.GetBytes(dataSize), 0, 4);
           


            stream.Write(data, 0, (int)dataSize);

            return stream;
        }

        public static Stream GenerateWavFileStream(UInt32 bitDepth, UInt32 totalSampleCount, Boolean isFloatingPoint, ushort channelCount, UInt32 sampleRate, double amplitude, int frequency, double phase)
        {
            Stream stream = new MemoryStream();
            stream.Position = 0;


            
            // RIFF header.
            // Chunk ID.
            stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);

            //UInt32 dataSize = (bitDepth / 8) * totalSampleCount * channelCount; ;
            //只支持32位数据
            UInt32 dataSize = (32 / 8) * totalSampleCount * channelCount;

            // Chunk size.
            stream.Write(BitConverter.GetBytes(dataSize + 36), 0, 4);

            // Format.
            stream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);



            // Sub-chunk 1.
            // Sub-chunk 1 ID.
            stream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);

            // Sub-chunk 1 size.
            stream.Write(BitConverter.GetBytes(16), 0, 4);

            // Audio format (floating point (3) or PCM (1)). Any other format indicates compression.
            //stream.Write(BitConverter.GetBytes((ushort)(isFloatingPoint ? 3 : 1)), 0, 2);
            //只支持定点数据
            stream.Write(BitConverter.GetBytes((ushort)1), 0, 2);

            // Channels.
            stream.Write(BitConverter.GetBytes(channelCount), 0, 2);

            // Sample rate.
            stream.Write(BitConverter.GetBytes(sampleRate), 0, 4);

            // Bytes rate.
            stream.Write(BitConverter.GetBytes(sampleRate * channelCount * (bitDepth / 8)), 0, 4);

            // Block align.
            stream.Write(BitConverter.GetBytes((ushort)channelCount * (bitDepth / 8)), 0, 2);

            // Bits per sample.
            stream.Write(BitConverter.GetBytes(bitDepth), 0, 2);



            // Sub-chunk 2.
            // Sub-chunk 2 ID.
            stream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);

            // Sub-chunk 2 size.

            stream.Write(BitConverter.GetBytes(dataSize), 0, 4);
            byte[] data = new byte[dataSize];
            //sampleGap = frequency * period / sampleRate

            double sampleGap = 1 / (double)sampleRate;
            double period = 1 / (double)frequency;

            double realAmplitude = amplitude;

            if (realAmplitude > 1)
            {
                realAmplitude = (double)1;
            }
            else if (realAmplitude < -1)
            {
                realAmplitude = (double)-1;
            }

            //4字节2通道
            for (int i = 0; i < dataSize / 4 / 2; i++)
            {
                double value = (Int32.MaxValue - 1) * amplitude * Math.Sin(2 * Math.PI * (double)frequency / (double)sampleRate * i + (double)phase % (2 * Math.PI));
                Int32 valueInInt = Convert.ToInt32(value);
                byte[] valueInBytes = BitConverter.GetBytes(valueInInt);
                data[i * 4] = valueInBytes[0];
                data[i * 4 + 1] = valueInBytes[1];
                data[i * 4 + 2] = valueInBytes[2];
                data[i * 4 + 3] = valueInBytes[3];

                data[(i + 1) * 4] = valueInBytes[0];
                data[(i + 1) * 4 + 1] = valueInBytes[1];
                data[(i + 1) * 4 + 2] = valueInBytes[2];
                data[(i + 1) * 4 + 3] = valueInBytes[3];
            }


            stream.Write(data, 0, (int)dataSize);

            return stream;
        }
    }
}