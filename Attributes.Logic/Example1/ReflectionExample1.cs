using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Attributes.Logic.Example1
{
    [Serializable]
    [DefaultMember("Main")]
    [DebuggerDisplay("Richter", Name = "Jeff", Target = typeof(ReflectionExample1))]
    public class ReflectionExample1
    {
        [Conditional("Debug")]
        [Conditional("Release")]
        public void DoSomething()
        {
        }

        public ReflectionExample1()
        {
            
        }
        
        [CLSCompliant(true)]
        [STAThread]
        public static void Execute()
        {
            //Вывод набора атрибутов, примененных к типу
            ShowAttributes(typeof(ReflectionExample1));

            //Получение и задание методов, связанных с типом
            var members =
                from m in typeof(ReflectionExample1).GetTypeInfo().DeclaredMembers.OfType<MethodBase>()
                where m.IsPublic
                select m;

            foreach (MemberInfo member in members)
            {
                //Вывод набора атрибутов, примененных к члену
                ShowAttributes(member);
            }
        }
        
        public static void ShowAttributes(MemberInfo attributeTarget)
        {
            var attributes = attributeTarget.GetCustomAttributes<Attribute>();

            Console.WriteLine("Attributes applied to {0}: {1}", attributeTarget.Name, (!attributes.Any() ? "None" : String.Empty));

            foreach (Attribute attribute in attributes)
            {
                //Вывод типа всех примененных атрибутов
                Console.WriteLine(" {0}", attribute.GetType().ToString());

                if (attribute is DefaultMemberAttribute)
                {
                    Console.WriteLine(" MemberName={0}", ((DefaultMemberAttribute) attribute).MemberName);
                }

                if (attribute is ConditionalAttribute)
                {
                    Console.WriteLine(" ConditionString={0}", ((ConditionalAttribute) attribute).ConditionString);
                }

                if (attribute is CLSCompliantAttribute)
                {
                    Console.WriteLine(" IsCompliant={0}", ((CLSCompliantAttribute) attribute).IsCompliant);
                }

                if (attribute is DebuggerDisplayAttribute dda)
                {
                    Console.WriteLine(" Value={0}, Name={1}, Target={2}", dda.Value, dda.Name, dda.Target);
                }
            }

            Console.WriteLine();
        }
    }
}