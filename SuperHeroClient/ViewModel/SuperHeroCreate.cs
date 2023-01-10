namespace SuperHeroClient.ViewModel
{
    public class SuperHeroCreate
    {
        public SuperHeroCreate()
        {
        }

        public SuperHeroCreate(string name, string description, string publisher, int age, string? powers, string? association, string? imgUrl)
        {
            Name = name;
            Description = description;
            Publisher = publisher;
            Age = age;
            Powers = powers;
            Association = association;
            ImgUrl = imgUrl;
        }

       public Guid Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public string Publisher { get; set; }
       public int Age { get; set; }
       public string? Powers { get; set; }
       public string? Association { get; set; }
       public string? ImgUrl { get; set; }
    }
}
