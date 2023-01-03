using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Domain.Entitie
{
    public class Superhero
    {
        public Superhero(string name, string description, string publisher, 
            int age, string powers, string association,string? imgUrl)
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
        public string Powers { get; set; }
        public string Association { get; set; }
        public string? ImgUrl { get; set; }

    }
}
