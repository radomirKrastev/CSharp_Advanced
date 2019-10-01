namespace CustomDoubleLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public Node(T value)
            {
                this.Value = value;
            }
        }

        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Count { get; private set; }

        public void AddHead(T element)
        {
            var newHead = new Node(element);

            if (this.Count == 0)
            {
                this.Head = this.Tail = newHead;
            }
            else
            {
                var oldHead = this.Head;
                oldHead.Previous = newHead;
                newHead.Next = oldHead;
                this.Head = newHead;
            }

            this.Count++;
        }

        public void AddTail(T element)
        {
            var newTail = new Node(element);

            if (this.Count == 0)
            {
                this.Head = this.Tail = newTail;
            }
            else
            {
                var oldTail = this.Tail;
                oldTail.Next = newTail;
                newTail.Previous = oldTail;
                this.Tail = newTail;
            }

            this.Count++;
        }
    }
}
