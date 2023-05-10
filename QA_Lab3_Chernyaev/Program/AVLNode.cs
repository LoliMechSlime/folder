namespace TreeLib;


/// <summary>
/// @brief Класс узла для хранения данных АВЛдерева.
/// Имеет вес для выполнения балансировки. Поумолчанию все равен нулю.
/// Имеет ссылки на два других узла и поля для ключа и значения.
/// </summary>
public class AVLNode : Node
{
    //Поле для хранения ссылки на левого потомка. По умолчанию ссылка равна NULL
    private AVLNode left = null;
    //Свойство для доступа к левому потомку.
    public new AVLNode Left { get => left; set => left = value; }
    //Поле для хранения ссылки на правого потомка. По умолчанию ссылка равна NULL
    private AVLNode right = null;
    //Свойство для доступа к правому потомку.
    public new AVLNode Right { get => right; set => right = value; }
    //Поле веса узла для выполнения балансировки дерева
    private int height = 0;
    //свойство для доступа к весу узла
    public int Height { get => height; set => height = value; }
    /// <summary>
    ///Конструктор для создания узла с заданым значением ключа и данных
    /// </summary>
    /// <param name="Value">Данные для занесения в узел</param>
    /// <param name="Key">Ключ для идентификации узла</param>
    public AVLNode(int Key, int Value) : base(Key, Value) { }
    /// <summary>
    ///Конструктор для создания узла с одинковым значением данных и ключа
    /// </summary>
    /// <param name="Value">Данные для занесения в узел</param>
    public AVLNode(int Value) : base(Value) { }
}
