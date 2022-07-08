using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Practicum.Classes;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskFinalB : BaseClass
    {
        // Successfull delivery ID - https://contest.yandex.ru/contest/22781/run-report/69284357/

        // ПРИНЦИП РАБОТЫ
        //  Данную задачу реализовал с помощью линейной структуры данных Stack.
        //  Сам Stack Я реализовал с помощью другой линейной структуры данных Single LinkedList.
        //  Во входном потоке, в строке через пробел дано выражение в обратной польской нотации.
        //  В цикле перебирая каждый элемент, если элемент - операнд, то ее добавляю в Stack, если элемент знак операции,
        //  то эта операция выполняется над требуемым количеством ранее добавленных операндов.
        //  Как только перебрали все элементы массива, вывожу верхний элемент из Stack.
        //  Сложение, вычетание, умножение и деление вынес в отдельный метод, по SOLID. S - Single Responsibilty.

        // ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ
        //  Из описания следует, что для реазации алгоритма мне нужно использовать - stack(Single LinkedList). 
        //  Реализация Stack через Single LinkedList обусловлена тем, что она не будет иметь ограничений по размеру, как в случае с реализацией через Array.
        //  Да, я мог реализовать Stack через Array, увеличивая максимальный размер Stack по необходимости, но тогда временная сложность была бы амортизированной. А так, временная сложность константная.
        //  Значения считываются слева напрво в порядке добавления. То есть, "3 1 +", из стека беру верхний элемент 1 и беру следующий элемент 3 и делаю сложению, как 3 + 1. 
        //  Результат сложения добавляется обратно в стек. Далее если в стеке остались еще значения, то повторяю операцию.

        // ВРЕМЕННАЯ СЛОЖНОСТЬ
        //  Перебор элементов массива "polishNotation" - O(N), где N элементы в массиве;
        //  Добавление в Stack - O(1), занимает константное время
        //  Получение/Удаление из Stack - O(1), занимает константное время
        //  Операции Сложение, Вычетание, Умножение и Деление - O(1), занимает константное время
        //  Так как, в Big O Notation мы не учитываем константы и коэффиценты, времення сложность будет - O(N), где N элементы в массиве

        // ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ
        //  Для реализации Stack через Single LinkedList, потребуется дополнительная память для хранения указателей(ссылок).
        //  Если в стек помещяются K элементов, то каждый из них будет храниться в памяти. Это означает, что должно быть использовано
        //  K - единиц памяти. Таким образом пространственная сложность - O(K), где К количество элементов в стеке. 

        #region Examples
        // 1) 2 1 + 3 * = 9
        // 2) 7 2 + 4 * 2 + = 38
        // 3) 7 -2 + 32 + -78 + = -41
        // 4) 7 -2 - 32 - -78 - = 55
        // 5) 45 23 4 + - 5 + 20 2 - - = 5
        // 6) 3 11 + = 14
        // 7) 3 11 5 + - = -13
        // 8) 3 11 + 5 - = 9
        // 9) 2 3 11 + 5 - * = 18
        // 10) 9 5 3 + 2 4 * - + = 9
        // 11) 8 2 5 * + 1 3 2 * + 4 - = 3
        // 12) 2 4 / 45 6 - 13 12 45 65 + - * = -1274
        #endregion
        public static void Execute()
        {
            InitReaderAndWriter();

            string[] polishNotation = Common.ReadStringArray(_reader);

            StackLinkedList stack = new StackLinkedList();
            for (int i = 0; i < polishNotation.Length; i++)
            {
                switch(polishNotation[i])
                {
                    case "+":
                        Add(stack);
                        break;
                    case "-":
                        Subtract(stack);
                        break;
                    case "*":
                        Multiply(stack);
                        break;
                    case "/":
                        Divide(stack);
                        break;
                    default:
                        int value = Convert.ToInt32(polishNotation[i]);
                        stack.Push(value);
                        break;
                }
            }

            _writer.WriteLine(stack.Pop());

            CloseReaderAndWriter();
        }

        static void Divide(StackLinkedList stack)
        {
            // При целочисленном делении с остатком, получаем неполный частный если делимое не 0, иначк неполный частный равняется 0.
            // Как следует из описании задачи, а именно в замечании про отрицательные числа и деление,
            // округлением вниз еще называют округлением к меньшему, если делимое положительное число, то результатом будет неполный частный,
            // если делимое отрицательное и оно не равняется умножению делителя и неполного частного, то увеличиваем значение неполного частного на единицу. 

            // делимое
            int a = stack.Pop();

            // Делитель
            int b = stack.Pop();

            // неполный частный
            int с = b == 0 ? b : a / b;
 
            int result = (a < 0 && a != b * с) ? с - 1 : с;

            stack.Push(result);
        }

        static void Multiply(StackLinkedList stack)
        {
            int b = stack.Pop();
            int a = stack.Pop();

            int c = a * b;
            stack.Push(c);
        }

        static void Subtract(StackLinkedList stack)
        {
            int b = stack.Pop();
            int a = stack.Pop();

            int c = a - b;
            stack.Push(c);
        }

        static void Add(StackLinkedList stack)
        {
            int b = stack.Pop();
            int a = stack.Pop();

            int c = a + b;
            stack.Push(c);
        }
    }
}
