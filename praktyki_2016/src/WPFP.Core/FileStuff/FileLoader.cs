namespace WPFP.Core.FileStuff
{
    class FileLoader
    {
        static public string[] LoadFileActions(string path)
        {
            string[] actions = System.IO.File.ReadAllLines(path);
            return actions;
        }
    }
}
