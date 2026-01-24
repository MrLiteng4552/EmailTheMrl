namespace AuctionSystem
{
    public class PriceChangedEventArgs : EventArgs
    {
        public decimal NewPrice { get; }
        public string BidderName { get; }

        public PriceChangedEventArgs(decimal newPrice, string bidderName)
        {
            NewPrice = newPrice;
            BidderName = bidderName;
        }
    }

    public class AuctionLot
    {
        public string ItemName { get; }
        public decimal CurrentPrice { get; private set; }

        public event EventHandler<PriceChangedEventArgs>? PriceChanged;

        public AuctionLot(string itemName, decimal initialPrice)
        {
            ItemName = itemName;
            CurrentPrice = initialPrice;
        }

        public void PlaceBid(Bidder bidder, decimal newPrice)
        {
            if (newPrice > CurrentPrice)
            {
                CurrentPrice = newPrice;
                Console.WriteLine($"{bidder.Name} делает ставку: {newPrice:F2}");

                OnPriceChanged(new PriceChangedEventArgs(newPrice, bidder.Name));
            }
            else
            {
                Console.WriteLine($"{bidder.Name} пытается сделать ставку: {newPrice:F2}");
                Console.WriteLine($" Ставка не принята. Сумма должна быть выше {CurrentPrice:F2}.");
            }
        }

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }
    }

    public class Bidder
    {
        public string Name { get; }

        public Bidder(string name)
        {
            Name = name;
        }

        public void OnPriceChanged(object? sender, PriceChangedEventArgs e)
        {
            if (e.BidderName != this.Name)
            {
                if (sender is AuctionLot lot)
                {
                    Console.WriteLine($" [{Name}]: Новая ставка на '{lot.ItemName}' - {e.NewPrice:F2} (от {e.BidderName}).");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            AuctionLot vase = new AuctionLot("Старинная ваза", 1000.00m);
            Console.WriteLine($"--- Аукцион начинается! Лот: '{vase.ItemName}'. Начальная цена: {vase.CurrentPrice:F2} ---");
            Bidder ivan = new Bidder("Иван");
            Bidder petr = new Bidder("Петр");
            Bidder anna = new Bidder("Анна");
            vase.PriceChanged += ivan.OnPriceChanged;
            Console.WriteLine($"Участник '{ivan.Name}' подписался на лот.");
            vase.PriceChanged += petr.OnPriceChanged;
            Console.WriteLine($"Участник '{petr.Name}' подписался на лот.");
            vase.PriceChanged += anna.OnPriceChanged;
            Console.WriteLine($"Участник '{anna.Name}' подписался на лот.");
            Console.WriteLine();
            vase.PlaceBid(ivan, 1200.00m);
            Console.WriteLine();
            vase.PlaceBid(anna, 1500.00m);
            Console.WriteLine();
            vase.PlaceBid(petr, 1300.00m);
        }
    }
}