namespace TreeLib;


/// <summary>
/// @brief Класс для создания структуры данных красно-черного дерева.
/// Корень и лист всегда черного цвета
/// У каждого красного узла оба ребенка черные.
/// </summary>
public class RBTree : BinSearchTree
{
    public RBTree(Node Node) : base(Node)
    {}

    public RBTree(int Value) : base(Value)
    {}

    public RBTree(int Key, int Value) : base(Key, Value)
    {}
}
