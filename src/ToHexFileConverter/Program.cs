
namespace ToHexFileConverter
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    class Program
    {
        [STAThread]
        static void Main( string[] args )
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if( dialog.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    DumpHex( dialog.FileName, dialog.FileName + ".txt" );
                }
                catch( Exception ex )
                {
                    Console.WriteLine( "Exception: " + ex );
                }
            }
        }

        private static void DumpHex( string binaryFile, string hexDumpFile )
        {
            bool finished = false;
            int readByte = 0;

            using( StreamWriter writer = new StreamWriter( hexDumpFile ) )
            using( FileStream reader = File.OpenRead( binaryFile ) )
            {
                while( !finished )
                {
                    if( (readByte = reader.ReadByte()) < 0 )
                    {
                        finished = true;
                    }

                    if( !finished )
                    {
                        // write out byte value
                        string b = string.Format( "{0:x2}", readByte );
                        writer.Write( b );
                        Console.Write( b );
                    }
                }
            }
        }
    }
}
