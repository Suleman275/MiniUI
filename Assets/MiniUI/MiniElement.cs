using UnityEngine.UIElements;

namespace MiniUI {
    public class MiniElement : VisualElement{
        public T CreateAndAddElement<T>() where T : VisualElement, new() {
            T element = new T();
            
            this.Add(element);

            return element;
        }
        
        public T CreateAndAddElement<T>(params string[] classes) where T : VisualElement, new() {
            T element = new T();

            foreach (string className in classes) {
                element.AddToClassList(className);
            }
            
            this.Add(element);
            
            return element;
        }
    }
}