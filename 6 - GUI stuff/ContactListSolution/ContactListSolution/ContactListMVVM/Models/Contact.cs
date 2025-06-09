namespace ContactListMVVM.Models
{
    public class Contact
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        public override string ToString()
        {
            return $"{Name} ({Email})";
        }
    }
}

