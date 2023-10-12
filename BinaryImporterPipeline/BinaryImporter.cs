using Microsoft.Xna.Framework.Content.Pipeline;
using System;

namespace BinaryImporterPipeline
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to import a file from disk into the specified type, TImport.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentImporter attribute to specify the correct file
    /// extension, display name, and default processor for this importer.
    /// </summary>

    [ContentImporter(".bin", DisplayName = "Binary Importer", DefaultProcessor = nameof(BinaryProcessor))]
    public class BinaryImporter : ContentImporter<byte[]>
    {
        public override byte[] Import(string filename, ContentImporterContext context)
        {
            return System.IO.File.ReadAllBytes(filename);
        }
    }
}
