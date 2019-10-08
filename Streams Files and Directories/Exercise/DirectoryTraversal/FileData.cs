namespace DirectoryTraversal
{
    public class FileData
    {
        //private string extension;
        private string name;
        private decimal size;

        public decimal Size => this.size;
        public string Name => this.name;

        public FileData(string name, decimal size)
        {
            //this.extension = extension;
            this.name = name;
            this.size = size;
        }
    }
}
