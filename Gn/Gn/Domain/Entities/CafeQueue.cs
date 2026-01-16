namespace Gn.Domain.Entities
{
    class CafeQueueSystem
    {
        private Queue<string> waitingQueue = new Queue<string>();
        private Dictionary<string, DateTime> reservations = new Dictionary<string, DateTime>();
        private readonly int totalTables;
        private int occupiedTables = 0;

        public CafeQueueSystem(int tablesCount)
        {
            totalTables = tablesCount;
        }

        public void ArriveRegularVisitor(string name)
        {
            Console.WriteLine($"\n→ {name} пришёл в кафе");

            if (HasFreeTable())
            {
                TakeTable(name);
            }
            else
            {
                waitingQueue.Enqueue(name);
                Console.WriteLine($"   {name} встал в очередь (позиция {waitingQueue.Count})");
            }
        }

        public void ArriveReservedVisitor(string name)
        {
            Console.WriteLine($"\n→ {name} пришёл по брони");

            if (reservations.ContainsKey(name))
            {
                var reservationTime = reservations[name];
                if ((DateTime.Now - reservationTime).TotalMinutes <= 15)
                {
                    Console.WriteLine($"   Бронь подтверждена ({name})");
                    reservations.Remove(name);
                    TakeTable(name);
                    return;
                }
                else
                {
                    Console.WriteLine($"   Бронь {name} просрочена!");
                    reservations.Remove(name);
                }
            }

            ArriveRegularVisitor(name);
        }

        public void TableFreed()
        {
            occupiedTables--;

            Console.WriteLine($"\nСтолик освободился. Свободных столов: {totalTables - occupiedTables}");

            if (waitingQueue.Count > 0)
            {
                string nextVisitor = waitingQueue.Dequeue();
                TakeTable(nextVisitor);
                Console.WriteLine($"   {nextVisitor} занял столик из очереди");
            }
        }

        public void MakeReservation(string name)
        {
            if (reservations.ContainsKey(name))
            {
                Console.WriteLine($"У {name} уже есть бронь");
                return;
            }

            reservations[name] = DateTime.Now;
            Console.WriteLine($"→ {name} забронировал столик на сейчас");
        }

        private bool HasFreeTable()
        {
            return occupiedTables < totalTables;
        }

        private void TakeTable(string name)
        {
            occupiedTables++;
            Console.WriteLine($"   {name} занял столик. Занято: {occupiedTables}/{totalTables}");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"\n=== Состояние кафе ===");
            Console.WriteLine($"Свободных столов: {totalTables - occupiedTables}/{totalTables}");
            Console.WriteLine($"Людей в очереди: {waitingQueue.Count}");

            if (reservations.Count > 0)
            {
                Console.WriteLine("Активные брони:");
                foreach (var r in reservations)
                {
                    Console.WriteLine($"  {r.Key} — {r.Value:HH:mm:ss}");
                }
            }
        }
    }
}
