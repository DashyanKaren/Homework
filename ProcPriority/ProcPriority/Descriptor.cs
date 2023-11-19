namespace ProcPriority
{
    internal partial class Program
    {
        internal class Descriptor
        {
            public string ProcessName { get; set; }
            public long ThreadId { get; set; }
            public int Prority { get; set; }
            public long Time { get; set; }
            public override string ToString()
            {
                return $"ProcessName ={this.ProcessName}, ThreadId ={this.ThreadId}, Priority = {this.Prority}, Time ={this.Time}";
            }
        }
    }
}
