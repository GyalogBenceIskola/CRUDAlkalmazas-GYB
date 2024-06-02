using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace Projekt_GYB
{
    class PostaRepository
    {
        public static string Valt { get; set; }

        public static bool Skip { get; set; } = true;

        public static char Split { get; set; } = ',';

        public static List<Posta> FindAll()
        {
            using (StreamReader reader = new StreamReader(Valt))
            {
                if (Skip)
                {
                    reader.ReadLine();
                }

                List<Posta> list = new List<Posta>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Posta tart = Posta.CreateFromLine(line, Split);
                    list.Add(tart);
                }

                return list;
            }
        }
        public static Posta FindById(int id)
        {
            foreach (Posta tart in FindAll())
            {
                if (tart.Id == id)
                {
                    return tart;
                }
            }

            return null;
        }
        public static List<Posta> FindAllByNameLike(string name)
        {
            return FindAll()
                .Where(tart => tart.FirstName.ToLower().Contains(name.ToLower()) || tart.LastName.ToLower().Contains(name.ToLower()))
                .ToList();
        }


        public static Posta Save(Posta tart)
        {
            List<Posta> list = FindAll();
            if (tart.Id == 0)
            {
                int maSplitId = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id > maSplitId)
                    {
                        maSplitId = list[i].Id;
                    }
                }
                tart.Id = maSplitId + 1;

                list.Add(tart);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id == tart.Id)
                    {
                        list[i] = tart;
                        break;
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(Valt))
            {
                writer.WriteLine("id,firstname,lastname,address,produckt,packid");

                for (int i = 0; i < list.Count; i++)
                {
                    writer.WriteLine(list[i].ToCSVLine());
                }
            }

            return tart;
        }

        public static void Delete(Posta tart)
        {
            List<Posta> list = FindAll();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == tart.Id)
                {
                    list.RemoveAt(i);
                    break;
                }
            }
            using (StreamWriter writer = new StreamWriter(Valt))
            {
                writer.WriteLine("id,firstname,lastname,address,produckt,packid");

                for (int i = 0; i < list.Count; i++)
                {
                    writer.WriteLine(list[i].ToCSVLine());
                }
            }
        }
    }
}