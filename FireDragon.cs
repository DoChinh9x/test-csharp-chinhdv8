using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Dragon
{
    public interface IReptile
    {
        ReptileEgg Lay();
    }

    public class FireDragon : IReptile
    {
        private bool hasHatched;

        public FireDragon()
        {
            hasHatched = false;
        }

        public ReptileEgg Lay()
        {
            if (hasHatched)
            {
                throw new InvalidOperationException("Cannot lay an egg after hatching.");
            }

            return new ReptileEgg(() => new FireDragon());
        }
    }

    public class ReptileEgg
    {
        private bool hasHatched;
        private readonly Func<IReptile> createReptile;

        public ReptileEgg(Func<IReptile> createReptile)
        {
            hasHatched = false;
            this.createReptile = createReptile;
        }

        public IReptile Hatch()
        {
            if (hasHatched)
            {
                throw new InvalidOperationException("Cannot hatch an egg more than once.");
            }

            hasHatched = true;
            return createReptile();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var fireDragon = new FireDragon();
            var egg = fireDragon.Lay();
            var childFireDragon = egg.Hatch();
        }
    }
}
