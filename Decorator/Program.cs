using System;

namespace Decorator
{
    internal class Program
    {
        abstract class Tree
        {
            public abstract void Display();
        }

        class ChristmasTree : Tree
        {
            public override void Display()
            {
                Console.WriteLine("Christmas tree");
            }
        }

        abstract class TreeDecorator : Tree
        {
            protected Tree tree;

            public void SetTree(Tree tree)
            {
                this.tree = tree;
            }

            public override void Display()
            {
                if (tree != null)
                {
                    tree.Display();
                }
            }
        }

        class OrnamentsDecorator : TreeDecorator
        {
            private string ornaments = "with ornaments";

            public override void Display()
            {
                base.Display();
                Console.WriteLine(ornaments);
            }
        }

        class GarlandDecorator : TreeDecorator
        {
            public override void Display()
            {
                base.Display();
                AddGarland();
            }

            private void AddGarland()
            {
                Console.WriteLine("with garland (lights on)");
            }
        }

        static void Main(string[] args)
        {
            ChristmasTree tree = new ChristmasTree();
            OrnamentsDecorator ornaments = new OrnamentsDecorator();
            GarlandDecorator garland = new GarlandDecorator();

            ornaments.SetTree(tree);
            garland.SetTree(ornaments);

            garland.Display();

            Console.Read();
        }
    }
}
