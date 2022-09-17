﻿using System.Text;

namespace BankClients.Repositories
{
    public class Repository
    {
        static Random random;
        public List<Client> Clients { get; set; }

        static Repository()
        {
            random = new();
        }

        public Repository(List<Client> clients)
        {
            this.Clients = clients;
        }

        /// <summary>
        /// Метод добавления рандомных сотрудников
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetRepository()
        {
            List<Client> newClient = new();
            for (int i = 0; i < 5; i++)
            {
                newClient.Add(new Client(
                    i + 1,
                    $"Сотрудник {i + 1}",
                    random.Next(18, 60),
                    "****  ******",
                    new DateTime(random.Next(1970, 2004), random.Next(1, 13), random.Next(1, 29)),
                    $"Город {i + 1}"
                    ));
            }
            return newClient;
        }

        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="arg"></param>
        public void Add(Client arg)
        {
            Clients.Add(arg);
            Clients[Clients.Count - 1] = arg;
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            int findIndex = -1;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].No == index) findIndex = i;
            }

            if (findIndex == -1) return; //если findIndex =-1, то ничего не будем делать

            for (int i = findIndex; i < Clients.Count - 1; i++)
            {
                Clients[findIndex] = Clients[findIndex + 1];
            }

            Clients.Remove(Clients[findIndex]);
        }

        /// <summary>
        /// Метод сохранения информации о сотруднике с использованием StreamWriter и StreamReader
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (Client e in Clients)
                {
                    string note = string.Empty;
                    note += $"{e.No}\t";
                    note += $"{e.Date,20}\t";
                    note += $"{e.FullName,40}\t";
                    note += $"{e.Age,3}\t";
                    note += $"{e.Passport,12}\t";
                    note += $"{e.DateOfBirth.ToShortDateString(),10}\t";
                    note += $"{e.PlaceOfBirth,22}\t";

                    streamWriter.WriteLine(note);
                }
            };

            using (StreamReader streamReader = new StreamReader(path, Encoding.Unicode))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null) //пока строка не будет пустой
                {
                    Console.WriteLine(streamReader.ReadLine());
                }
            };
        }


        /// <summary>
        /// Сортировка по дате Дней рождения сотрудников по Возрастанию
        /// </summary>
        public void SortByDateOfBirth_Ascending()
        {
            //public void Sort(int index, int count, IComparer<T> comparer);
            Clients.Sort(SortAscending);
        }
        private int SortAscending(Client x, Client y)
        {
            return x.DateOfBirth < y.DateOfBirth ? -1 : x.DateOfBirth > y.DateOfBirth ? 1 : 0;
        }

        /// <summary>
        /// Сортировка по дате Дней рождения сотрудников по Убыванию
        /// </summary>
        public void SortByDateOfBirth_Descending()
        {
            Clients.Sort(SortDescending);
        }
        private int SortDescending(Client x, Client y)
        {
            //-1, 1, 0
            return x.DateOfBirth < y.DateOfBirth ? 1 : x.DateOfBirth > y.DateOfBirth ? -1 : 0;
        }

        /// <summary>
        /// Печать информации о сотрудниках
        /// </summary>
        public string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Clients.Count; i++)
            {
                stringBuilder.Append($"{Clients[i]}\n");
            }
            return stringBuilder.ToString();
        }
    }
}
