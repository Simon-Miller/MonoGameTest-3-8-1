using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace BinaryImporterPipeline
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to apply custom processing to content data, converting an object of
    /// type TInput to TOutput. The input and output types may be the same if
    /// the processor wishes to alter data without changing its type.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentProcessor attribute to specify the correct
    /// display name for this processor.
    /// </summary>
    [ContentProcessor(DisplayName = "Binary Processor")]
    public class BinaryProcessor : ContentProcessor<byte[], byte[]>
    {
        public override byte[] Process(byte[] input, ContentProcessorContext context)
        {
            return input;
        }
    }

    /// <summary>
    /// Pipeline will use this to process the internal byte[] (maybe we'll have it compressed in future?)
    /// To the output un-compressed (not that it's currently compressed, by MonoGame doesn't know that)
    /// </summary>    
    public class BinaryReader : ContentTypeReader<byte[]>
    {
        protected override byte[] Read(ContentReader input, byte[] existingInstance)
        {
            byte[] rawData = input.ReadBytes((int)input.BaseStream.Length);

            return rawData;
        }
    }
}
