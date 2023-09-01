using Iterator;

MyCollection myCollection = new MyCollection();
var item = (object)2;
myCollection.Add(1);
myCollection.Add(item);
myCollection.Add(3);

foreach (var colItem in myCollection)
{
    Console.WriteLine(colItem);
}

