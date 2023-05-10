namespace TreeLib;

/// <summary>
/// @brief Класс для создания структуры данных двоичного дерева поиска.
/// Иерархическая структура данных сотоящая из узлов, хранящие ключ-значение и имеет двух детей.
/// Данные добаляются по правилам:
/// 1. Если в дерево нет узлов, то новый узел становится корнем.
/// 2. Если ключ нового узла меньше ключа текущего узла, вставка рекурсивно идет налево.
/// 3. Если ключ нового узла больше или равен ключа текущего узла, вставка рекурсивно идет направо.
/// При прохождении дерева узлы маршрута складываются в стек.
/// Пример реализации дерева:
///@image{inline} html Tree.png "Двоичное дерево поиска"
/// </summary>
public class BinSearchTree
{
    ///Поле корня дерева, представляющие из себя узел.
    private Node root;

    /// <summary>
    ///Конструктор дерева из имеющегося узла
    /// </summary>
    /// <param name="Node">Проинициализированный узел</param>
    public BinSearchTree(Node Node) => root = Node;

    /// <summary>
    ///Конструктор для создания дерева с корнем с разным ключом и значением
    /// </summary>
    /// <param name="Key">Ключ узла</param>
    /// <param name="Value">Данные узла</param>
    public BinSearchTree(int Key, int Value) => root = new Node(Key, Value);

    /// <summary>
    ///Конструктор для создания дерева с корнем с одним ключом и значением
    /// </summary>
    /// <param name="Value">Данные узла</param>
    public BinSearchTree(int Value) => root = new Node(Value);

    /// <summary>
    /// Вставка нового узла с разными ключом и значением в дерево.
    /// </summary>
    /// <param name="Key">Ключ узла</param>
    /// <param name="Value">Данные узла</param>
    public void Insert(int Key, int Value) => Insert(root, Key, Value);
    /// <summary>
    /// Вставка нового узла с одинаковым ключом и значением в дерево.
    /// </summary>
    /// <param name="Value">Данные узла</param>
    public void Insert(int Value) => Insert(root, Value);

    /// <summary>
    /// Защищенный метод для вставки узла в дерево от определнного узла.
    /// В данном классе вставка начинается от дерева и идет по рекурсии до необхордимого места.
    /// Метод для различных ключа и значения.
    /// </summary>
    /// <param name="Node">Узел, с которого начинается вставка.</param>
    /// <param name="Key">Ключ узла</param>
    /// <param name="Value">Данные узла</param>
    protected virtual void Insert(Node Node, int Key, int Value)
    {
        if (Key < Node.Key)
        {
            if (Node.Left == null)
                Node.Left = new Node(Key, Value);
            else Insert(Node.Left, Key, Value);
        }
        else if (Key >= Node.Key)
        {
            if (Node.Right == null)
                Node.Right = new Node(Key, Value);
            else Insert(Node.Right, Key, Value);
        }
    }
    /// <summary>
    /// Защищенный метод для вставки узла в дерево от определнного узла.
    /// В данном классе вставка начинается от дерева и идет по рекурсии до необхордимого места.
    /// Метод для одинаковых ключа и значения.
    /// </summary>
    /// <param name="Node">Узел, с которого начинается вставка.</param>
    /// <param name="Value">Данные узла</param>
    protected virtual void Insert(Node Node, int Value)
    {
        if (Value < Node.Value)
        {
            if (Node.Left == null)
                Node.Left = new Node(Value);
            else Insert(Node.Left, Value);
        }
        else if (Value >= Node.Value)
        {
            if (Node.Right == null)
                Node.Right = new Node(Value);
            else Insert(Node.Right, Value);
        }
    }

    /// <summary>
    /// Поиск узла с определнным ключом в дереве.
    /// Поскольку дерево создается отсортированым, то сложность поиска оценивается как О(LogN)
    /// </summary>
    /// <param name="Key">Ключ необходимого узла</param>
    /// <returns>Узел с данным ключом</returns>
    public Node Search(int Key) => Search(root, Key);

    /// <summary>
    /// Защищенный метод для вставки узла в дерево от определнного узла.
    /// В данном классе вставка начинается от дерева и идет по рекурсии до необходимого места.
    /// Метод для одинаковых ключа и значения.
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    /// <param name="Key">Ключ необходимого узла</param>
    /// <returns>Узел с данным ключом</returns>
    protected virtual Node Search(Node Node, int Key)
    {
        if (Node == null)
            return null;
        if (Node.Key == Key)
            return Node;
        return Key < Node.Key ? Search(Node.Left, Key) : Search(Node.Right, Key);
    }
    /// <summary>
    /// Удаление узла с определенным ключом в дереве.
    /// </summary>
    /// <param name="Key">Ключ необходимого узла</param>
    ///<returns>Узел с перезаписанными данными в слечае, если данные по ссылке не передаются</returns>
    public Node Delete(int Key) => Delete(root, Key);

    /// <summary>
    /// Защищенный метод для удаления узла с определенным ключом в дереве.
    /// В данном классе удаление начинается от дерева и идет по рекурсии до необходимого места.
    /// Удаление работает по правилам:
    /// Если элемент является листом, то заменяется на null
    /// Если элемент имеет одного ребенка, то он заменяется на ребенка
    /// Если элемент имеет двух детей, наибольший элемент левой ветки встает на место родителя. Этот ребенок удаляется в последствии.
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    /// <param name="Key">Ключ необходимого узла</param>
    protected virtual Node Delete(Node Node, int Key)
    {
        if (Node == null)
            return null;
        else if (Key < Node.Key)
            Node.Left = Delete(Node.Left, Key);
        else if (Key > Node.Key)
            Node.Right = Delete(Node.Right, Key);
        else
        {
            if (Node.Left == null || Node.Right == null)
                Node = (Node.Left == null) ? Node.Right : Node.Left;
            else
            {
                Node maxInLeft = GetMax(Node.Left);
                Node.Key = maxInLeft.Key;
                Node.Value = maxInLeft.Value;
                Node.Right = Delete(Node.Right, maxInLeft.Key);
                Node.Left = Delete(Node.Left, maxInLeft.Key);
            }
        }
        return Node;
    }
    /// <summary>
    /// Поиск узла с минимальным значением ключа от данного узла.
    /// </summary>
    /// <param name="Node">Начальынй узел</param>
    /// <returns>Крайний левый узел</returns>
    public Node GetMin(Node Node)
    {
        if (Node == null)
            return null;
        if (Node.Left == null)
            return Node;
        return GetMin(Node.Left);
    }

    /// <summary>
    /// Поиск узла с максимальным значением ключа от данного узла.
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    /// <returns>Крайний правый узел</returns>
    public Node GetMax(Node Node)
    {
        if (Node == null)
            return null;
        if (Node.Right == null)
            return Node;
        return GetMax(Node.Right);
    }

    /// <summary>
    /// Вывод данных дерева симметричным обходом.
    /// Производит обход дерева в порядке возрастания ключа.
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    /// <param name="Output">Список в кторый выводятся значения.</param>
    public void PrintTree(Node Node, List<int> Output)
    {
        if (Node == null)
            return;
        PrintTree(Node.Left, Output);
        Output.Add(Node.Value);
        PrintTree(Node.Right, Output);
    }

    /// <summary>
    /// Удаление всего дерева обратным обходом.
    /// </summary>
    public void DeleteTree() => DeleteTree(root);

    /// <summary>
    /// Защищенный метод для удаления всего дерева обратным обходом с определенно узла.
    /// Позволяет безопастно удалить дерево в языках с ручным управление памятью.
    /// </summary>
    /// <param name="Node">Начальный узел</param>
    protected void DeleteTree(Node Node)
    {
        if (Node == null)
            return;
        Delete(Node.Left, Node.Left.Key);
        Delete(Node.Right, Node.Right.Key);
        Delete(Node, Node.Key);
    }

    /// <summary>
    /// Копирование дерева в другое дерево путем прямого обхода.
    /// </summary>
    /// <param name="targetTree">Целевое дерево</param>
    public void CopyTree(BinSearchTree targetTree) => CopyTree(root, targetTree.root);

    /// <summary>
    /// Защищенный метод для копирования дерева в другое дерево путем прямого обхода.
    /// </summary>
    /// <param name="SourceNode">Начальное дерево</param>
    /// <param name="targetTree">Целевое дерево</param>
    protected virtual void CopyTree(Node SourceNode, Node TargetNode)
    {
        if (SourceNode == null)
            return;
        Insert(TargetNode, SourceNode.Key, SourceNode.Value);
        CopyTree(SourceNode.Left, TargetNode);
        CopyTree(SourceNode.Right, TargetNode);
    }

}
