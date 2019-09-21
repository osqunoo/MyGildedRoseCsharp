using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    
    public class UpdateItemStrategyModel
    {
        private const int MAX_LIMIT = 50;
        private const int MIN_LIMIT = 0;

        private static Dictionary<Item, Func<Item, Item>> strategyDict = new Dictionary<Item, Func<Item, Item>>{
            {new Item("Sulfuras, Hand of Ragnaros"), LegendaryItem },
            {new Item("Aged Brie"), updateCheese },
            {new Item("Backstage passes to a TAFKAL80ETC concert"), updateBackstage }
        };

            public static Item UpdateItem(Item i)
            {
                if (strategyDict.ContainsKey(i))
                    return strategyDict[i](i);
                else
                    return RegularItem(i);
            }
            private static Item updateBackstage(Item item)
            {
                decreaseSellIn(item);
                if (item.SellIn < 10)
                {
                    increaseQuality(item);
                }

                if (item.SellIn < 5)
                {
                    increaseQuality(item);
                }
                if (isExpired(item))
                {
                    item.Quality -= item.Quality;
                }
            return item;

            }
            private static Item RegularItem(Item item)
            {
                decreaseSellIn(item);
                decreaseQuality(item);
                if (isExpired(item))
                {
                    decreaseQuality(item);
                }
             return item;
            }
            private static Item LegendaryItem(Item item)
            {
                return item;
            }
            private static Item updateCheese(Item item)
            {
                decreaseSellIn(item);
                increaseQuality(item);
                if (isExpired(item))
                {
                    increaseQuality(item);
                }
                 return item;
            }
            private static bool isExpired(Item item)
            {
                return item.SellIn < 0;
            }
            private static void increaseQuality(Item item)
            {
                if (item.Quality < MAX_LIMIT)
                {
                    item.Quality += 1;
                }
            }
            private static void decreaseSellIn(Item item)
            {
                item.SellIn -= 1;
            }
            private static void decreaseQuality(Item item)
            {
                if (item.Quality > MIN_LIMIT)
                {
                    item.Quality -= 1;
                }
            }
    }


}
