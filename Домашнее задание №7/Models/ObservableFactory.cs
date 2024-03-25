using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive.Subjects;

namespace Домашнее_задание__7.Class
{
    public class ObservableFactory
    {
        public static IObservable<CollectionChangedEventArgs<T>> CreateObservable<T>(ObservableCollection<T> collection)
        {
            return new ObservableCollectionWrapper<T>(collection);
        }

        public class CollectionChangedEventArgs<T>
        {
            public T Item { get; }
            public CollectionChangedAction Action { get; }

            public CollectionChangedEventArgs(T item, CollectionChangedAction action)
            {
                Item = item;
                Action = action;
            }
        }

        public enum CollectionChangedAction
        {
            Add,
            Remove,
            Replace
        }

        public class ObservableCollectionWrapper<T> : IObservable<CollectionChangedEventArgs<T>>, IDisposable
        {
            private readonly ObservableCollection<T> _collection;
            private readonly Subject<CollectionChangedEventArgs<T>> _subject = new Subject<CollectionChangedEventArgs<T>>();

            public ObservableCollectionWrapper(ObservableCollection<T> collection)
            {
                _collection = collection;
                _collection.CollectionChanged += CollectionChangedHandler;

                foreach (T item in _collection)
                {
                    _subject.OnNext(new CollectionChangedEventArgs<T>(item, CollectionChangedAction.Add));
                }
            }

            private void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (T item in e.NewItems)
                    {
                        _subject.OnNext(new CollectionChangedEventArgs<T>(item, CollectionChangedAction.Add));
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (T item in e.OldItems)
                    {
                        _subject.OnNext(new CollectionChangedEventArgs<T>(item, CollectionChangedAction.Remove));
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    foreach (T item in e.OldItems)
                    {
                        _subject.OnNext(new CollectionChangedEventArgs<T>(item, CollectionChangedAction.Remove));
                    }
                    foreach (T item in e.NewItems)
                    {
                        _subject.OnNext(new CollectionChangedEventArgs<T>(item, CollectionChangedAction.Add));
                    }
                }
            }

            public IDisposable Subscribe(IObserver<CollectionChangedEventArgs<T>> observer)
            {
                return _subject.Subscribe(observer);
            }

            public void Dispose()
            {
                _subject.Dispose();
                _collection.CollectionChanged -= CollectionChangedHandler;
            }
        }
    }
}
