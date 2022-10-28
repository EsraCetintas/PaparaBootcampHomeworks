using Owner.API.Model;
using System;
using System.Collections.Generic;

namespace Owner.API.Data
{
    public class OwnerData
    {
         List<Model.Owner> owners = new List<Model.Owner>
        {

                new Model.Owner
                {
                    Id = 1,
                    Name = "Esra",
                    LastName = "Çetintaş",
                    Date = new DateTime(2022,10,26),
                    Description = "Description Description Description",
                    Type = "type1"
                },
                new Model.Owner
                {
                    Id = 2,
                    Name = "Samet",
                    LastName = "Kayıkçı",
                    Date = new DateTime(2022,9,18),
                    Description = "Description Description Description",
                    Type = "type2"
                },
                new Model.Owner
                {
                    Id = 3,
                    Name = "Nuray",
                    LastName = "Kılıç",
                    Date = new DateTime(2021,1,5),
                    Description = "Description Description Description",
                    Type = "type3"
                },
                new Model.Owner
                {
                    Id = 4,
                    Name = "Uğurcan",
                    LastName = "Gürsu",
                    Date = new DateTime(2015,12,24),
                    Description = "Description Description Description",
                    Type = "type4"
                },
                new Model.Owner
                {
                    Id = 5,
                    Name = "Beşir",
                    LastName = "Gündüz",
                    Date = new DateTime(2015,12,24),
                    Description = "Description Description Description",
                    Type = "type4"
                }
        };

        public List<Model.Owner> GetOwners()
        {
            return owners;
        }
    }
}
