namespace ForDiagram
{
    internal class MyPropery
    {

        public int  Id { get; set; }

        public  string Name { get; set; }
        public double Value { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            return $"id:{Id}. Название: {Name}, Значение: {Value}, цвет: {Color} ";
        }
    }
}