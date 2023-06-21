namespace Project1
{
    public class Company
    {
        public DateTime CreatedDate { get; set; }

        public string? CompanyName { get; set; }

        public decimal SharePrice { get; set; }

        public string? Code { get; set; }
    }

    public class custMsg
    {
        public string Message{ set; get;}
        public string Code { set; get;}
    }
}