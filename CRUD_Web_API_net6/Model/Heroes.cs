namespace CRUD_Web_API_net6.Model
{
    public class Heroes
    {
        public int id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
    }
}
