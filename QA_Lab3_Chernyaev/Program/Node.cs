namespace TreeLib;

/// <summary>
/// @brief Класс узла для хранения данных в виде дерева.
/// Имеет ссылки на два других узла и поля для ключа и значения
/// </summary>
public class Node
{
    ///Поле для хранения ключа для доступа к узлу
    private int key;
    ///Свойство для доступа к полю с ключом узла
    public int Key { get => key; set => key = value; }
    ///Поле для хранения значения узла
    private int value;
    ///Свойство для доступа к полю значения узла
    public int Value { get => value; set => this.value = value; }

    //Поле для хранения ссылки на левого потомка. По умолчанию ссылка равна NULL
    private Node left = null;
    //Свойство для доступа к левому потомку.
    public Node Left { get => left; set => left = value; }
    //Поле для хранения ссылки на правого потомка. По умолчанию ссылка равна NULL
    private Node right = null;
    //Свойство для доступа к правому потомку.
    public Node Right { get => right; set => right = value; }

    /// <summary>
    ///Конструктор для создания узла с одинковым значением данных и ключа
    /// </summary>
    /// <param name="Value">Данные для занесения в узел</param>
    public Node(int Value)
    {
        key = Value;
        value = Value;
    }

    /// <summary>
    ///Конструктор для создания узла с заданым значением ключа и данных
    /// </summary>
    /// <param name="Value">Данные для занесения в узел</param>
    /// <param name="Key">Ключ для идентификации узла</param>
    public Node(int Key, int Value)
    {
        key = Key;
        value = Value;
    }
}
