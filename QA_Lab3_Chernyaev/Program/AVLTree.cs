namespace TreeLib;

/// <summary>
/// @brief Класс для создания структуры данных АВЛ дерева.
/// Имеет балансировку дерева при изменении узлов для сохранения сложности О(LogN) при работе с деревом.
/// Разница между высотами дочернего узла всегда равна 1 или 0 по модулю.
/// </summary>
public class AVLTree : BinSearchTree
{
    ///Поле корня дерева, представляющие из себя АВЛ узел.
    #pragma warning disable 0649
    private AVLNode root = null;
    /// <summary>
    ///Конструктор дерева из имеющегося узла
    /// </summary>
    /// <param name="Node">Проинициализированный узел</param>
    public AVLTree(AVLNode Node) : base(Node) { }

    /// <summary>
    ///Конструктор для создания дерева с корнем с разным ключом и значением
    /// </summary>
    /// <param name="Key">Ключ узла</param>
    /// <param name="Value">Данные узла</param>
    public AVLTree(int Key, int Value) : base(Key, Value) { }

    /// <summary>
    ///Конструктор для создания дерева с корнем с одним ключом и значением
    /// </summary>
    /// <param name="Value">Данные узла</param>
    public AVLTree(int Value) : base(Value) { }

    /// <summary>
    /// Получение высоты узла
    /// Не существующий узел имеет высоту -1
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    ///<returns>Высота начального узла</returns>
    private static int GetHeight(AVLNode Node) => Node == null ? -1 : Node.Height;
    /// <summary>
    /// Обновление высоты узла в связи с изменением узлов дерева
    /// Во время скрутки стека из-за рекурсии обновляет высоты всех пройденых элементов
    /// Высота вычисляется по формуле \f$Max(HeightLeft,HeightRight)+1\f$
    /// </summary>
    private static void UpdateHeight(AVLNode Node) => Node.Height = Math.Max(GetHeight(Node.Left), GetHeight(Node.Right)) + 1;

    /// <summary>
    /// Проверка текущего баланса узла
    /// Дерево перегружено влево, если число отрицательное
    /// Дерево перегружено вправо, если число положительное
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    ///<returns>Значение перугрузки</returns>
    private static int GetBalance(AVLNode Node) => Node == null ? 0 : GetHeight(Node.Right) - GetHeight(Node.Left);

    /// <summary>
    /// Поменять местами два узла в дереве
    /// </summary>
    /// <param name="a">Первый узел</param>
    /// <param name="b">Второй узел</param>
    private static void Swap(Node a, Node b)
    {
        var aKey = a.Key;
        a.Key = b.Key;
        b.Key = aKey;
        var aValue = a.Value;
        a.Value = b.Value;
        b.Value = aValue;
    }

    /// <summary>
    /// Правый поворот узла в дереве.
    /// После поворота высоты пересчитывются.
    /// </summary>
    /// <param name="Node">Узел для поворота</param>
    private static void RightRotate(AVLNode Node)
    {
        Swap(Node, Node.Left);
        AVLNode buffer = Node.Right;
        Node.Right = Node.Left;
        Node.Left = Node.Right.Left;
        Node.Right.Left = Node.Right.Right;
        Node.Right.Right = buffer;
        UpdateHeight(Node);
        UpdateHeight(Node.Right);
    }

    /// <summary>
    /// Левый поворот узла в дереве.
    /// После поворота высоты пересчитывются.
    /// </summary>
    /// <param name="Node">Узел для поворота</param>
    private static void LeftRotate(AVLNode Node)
    {
        Swap(Node, Node.Right);
        AVLNode buffer = Node.Left;
        Node.Left = Node.Right;
        Node.Right = Node.Left.Right;
        Node.Left.Right = Node.Left.Left;
        Node.Left.Left = buffer;
        UpdateHeight(Node);
        UpdateHeight(Node.Left);
    }

    /// <summary>
    /// Проверка балансировки детей.
    /// Проводит балансировку дерева.
    /// После поворота высоты пересчитывются.
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    private static void Balance(AVLNode Node)
    {
        int balance = GetBalance(Node);
        if (balance == -2)
        {
            if (GetBalance(Node.Left) == 1)
                LeftRotate(Node.Left);
            RightRotate(Node);
        }
        else if (balance == 2)
        {
            if (GetBalance(Node.Right) == -1)
                RightRotate(Node.Right);
            LeftRotate(Node);
        }
    }
    /// <summary>
    /// Вставка работает по принципу бинарного дерева.
    /// После вставки вычисляет высоты и проводит перебалансирование.
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    protected override void Insert(Node Node, int Key, int Value)
    {
        base.Insert(Node, Key, Value);
        UpdateHeight(root);
        Balance(root);
    }

    /// <summary>
    /// Удаление работает по принципу бинарного дерева.
    /// После удаления вычисляет высоты и проводит перебалансирование.
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    protected override Node Delete(Node Node, int Key)
    {
        if (Node != null)
        {
            UpdateHeight(root);
            Balance(root);
        }
        return base.Delete(Node, Key);
    }
}
