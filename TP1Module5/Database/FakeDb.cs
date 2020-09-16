using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP1Module5.Models;

namespace TP1Module5.Database
{
    public class FakeDb
    {

        private static readonly Lazy<FakeDb> lazy =
            new Lazy<FakeDb>(() => new FakeDb());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDb Instance { get { return lazy.Value; } }

        private FakeDb()
        {
            this.GetMeuteDeChats = new List<Chat>();
            this.InitialiserDatas();
        }

        public List<Chat> GetMeuteDeChats { get; private set; }


        private void InitialiserDatas()
        {
            var i = 1;

            GetMeuteDeChats.Add(new Chat { Id = i++, Nom = "Felix", Age = 3, Couleur = "Roux" });
            GetMeuteDeChats.Add(new Chat { Id = i++, Nom = "Minette", Age = 1, Couleur = "Noire" });
            GetMeuteDeChats.Add(new Chat { Id = i++, Nom = "Miss", Age = 10, Couleur = "Blanche" });
            GetMeuteDeChats.Add(new Chat { Id = i++, Nom = "Garfield", Age = 6, Couleur = "Gris" });
            GetMeuteDeChats.Add(new Chat { Id = i++, Nom = "Chatran", Age = 4, Couleur = "Fauve" });
            GetMeuteDeChats.Add(new Chat { Id = i++, Nom = "Minou", Age = 2, Couleur = "Blanc" });
            GetMeuteDeChats.Add(new Chat { Id = i, Nom = "Bichette", Age = 12, Couleur = "Rousse" });

        }
    }
}
