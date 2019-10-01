using System;

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

        private Node head;
        private Node tail;

        public Node Head
        {
            get
            {
                ValidateIfListIsEmpty();

                return this.head;
            }

            private set { this.head = value; }
        }

        public Node Tail
        {
            get
            {
                ValidateIfListIsEmpty();

                return this.tail;
            }

            private set { this.tail = value; }
        }

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

        public T RemoveHead()
        {
            ValidateIfListIsEmpty();

            var value = this.Head.Value;

            if (this.Head.Equals(this.Tail))
            {
                this.Head = this.Tail = null;
            }
            else
            {
                var newHead = this.Head.Next;
                newHead.Previous = null;
                this.Head.Next = null;
                this.Head = newHead;
            }

            this.Count--;
            return value;
        }

        public T RemoveTail()
        {
            ValidateIfListIsEmpty();

            var value = this.Tail.Value;

            if (this.Tail.Equals(this.Head))
            {
                this.Head = this.Tail = null;
            }
            else
            {
                var newTail = this.Tail.Previous;
                newTail.Next = null;
                this.Tail.Previous = null;
                this.Tail = newTail;
            }

            this.Count--;
            return value;
        }

        public void ValidateIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }
    }
}
