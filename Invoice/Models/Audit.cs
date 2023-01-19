namespace Invoice.Models
{
    public class Audit
    {
        public string  CreateBy { get; set; }
        public DateTimeOffset  CreateOn { get; set; }
        public string  UpdateBy { get; set; }
        public DateTimeOffset UpdateOn { get; set; }
        public string  DeleteBy { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
    }
}
