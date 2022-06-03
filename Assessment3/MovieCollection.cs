// Phase 2
// An implementation of MovieCollection ADT
// 2022


using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in a binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode lchild; // reference to its left child 
	private BTreeNode rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicates in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode root; // movies are stored in a binary search tree and the root of the binary search tree is 'root' 
	private int count; // the number of (different) movies currently stored in this movie collection 



	// get the number of movies in this movie colllection 
	// pre-condition: nil
	// post-condition: return the number of movies in this movie collection and this movie collection remains unchanged
	public int Number { get { return count; } }

	// constructor - create an object of MovieCollection object
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

	// Check if this movie collection is empty
	// Pre-condition: nil
	// Post-condition: return true if this movie collection is empty; otherwise, return false.
	public bool IsEmpty()
	{
		return root == null;
	}

	// Insert a movie into this movie collection
	// Pre-condition: nil
	// Post-condition: the movie has been added into this movie collection and return true, if the movie is not in this movie collection; otherwise, the movie has not been added into this movie collection and return false.
	public bool Insert(IMovie movie)
	{
		if ( root == null && Search(movie) == false)
        {
			root = new BTreeNode(movie);
			count++;
			return true;
        }
        else if( root != null && Search(movie) == false)
        {
			Insert(movie, root);
			count++;
			return true;
        }
        else
        {
			return false;
        }
	}

	//Private function created to insert item in correct position if the
	//root is not null
	//Used in Insert(IMovie movie) function
	private void Insert(IMovie movie, BTreeNode ptr)
	{
		if (movie.CompareTo(ptr.Movie) < 0)
		{
			if (ptr.LChild == null)
				ptr.LChild = new BTreeNode(movie);
			else
				Insert(movie, ptr.LChild);
		}
		else
		{
			if (ptr.RChild == null)
				ptr.RChild = new BTreeNode(movie);
			else
				Insert(movie, ptr.RChild);
		}
	}



	// Delete a movie from this movie collection
	// Pre-condition: nil
	// Post-condition: the movie is removed out of this movie collection and return true, if it is in this movie collection; return false, if it is not in this movie collection
	public bool Delete(IMovie movie)
	{
		// search for item and its parent
		BTreeNode ptr = root; // search reference
		BTreeNode parent = null; // parent of ptr
		while ((ptr != null) && (movie.CompareTo(ptr.Movie) != 0))
		{
			parent = ptr;
			if (movie.CompareTo(ptr.Movie) < 0) // move to the left child of ptr
				ptr = ptr.LChild;
			else
				ptr = ptr.RChild;
		}

		if (ptr != null) // if the search was successful
		{
			// case for movie searched has two children
			if ((ptr.LChild != null) && (ptr.RChild != null))
			{
				// find the right-most node in left subtree of ptr
				if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
				{
					ptr.Movie = ptr.LChild.Movie;
					ptr.LChild = ptr.LChild.LChild;
				}
				else
				{
					BTreeNode p = ptr.LChild;
					BTreeNode pp = ptr; 
					while (p.RChild != null)
					{
						pp = p;
						p = p.RChild;
					}
					// copy the item at p to ptr
					ptr.Movie = p.Movie;
					pp.RChild = p.LChild;
				}
			}
			else // cases for movie searched has no or only one child
			{
				BTreeNode c;
				if (ptr.LChild != null)
					c = ptr.LChild;
				else
					c = ptr.RChild;

				// remove node ptr
				if (ptr == root) //need to change root
					root = c;
				else
				{
					if (ptr == parent.LChild)
						parent.LChild = c;
					else
						parent.RChild = c;
				}				
			}
			count--;
			return true;

		}
        else// failed to search item
        {
			return false;
        }
	}

	// Search for a movie in this movie collection
	// pre: nil
	// post: return true if the movie is in this movie collection;
	//	     otherwise, return false.
	public bool Search(IMovie movie)
	{
		return Search(movie, root);
	}

	//private function created to search for movie we searching for
	//Used in Search(IMovie movie) function
	private bool Search(IMovie movie, BTreeNode ptr)
	{
		if (ptr != null)
		{
			if (movie.CompareTo(ptr.Movie) == 0)
				return true;
			else
				if (movie.CompareTo(ptr.Movie) < 0)
				return Search(movie, ptr.LChild);
			else
				return Search(movie, ptr.RChild);
		}
		else
			return false;
	}

	// Search for a movie by its title in this movie collection  
	// pre: nil
	// post: return the reference of the movie object if the movie is in this movie collection;
	//	     otherwise, return null.
	public IMovie Search(string movietitle)
	{
		return Search(movietitle, root);
	}

	//private function created to find for movie
	//we are searching for with a pointer
	//Used in Search(string movietitle)
	private IMovie Search(string movietitle, BTreeNode ptr)
	{
		if (ptr != null)
		{
			if (movietitle.CompareTo(ptr.Movie.Title) == 0)
				return ptr.Movie;
			else
				if (movietitle.CompareTo(ptr.Movie.Title) < 0)
				return Search(movietitle, ptr.LChild);
			else
				return Search(movietitle, ptr.RChild);
		}
		else
			return null;
	}

	//global variable to adjust the index for array used in ToArray() function
	int i = 0;

	// Store all the movies in this movie collection in an array in the dictionary order by their titles
	// Pre-condition: nil
	// Post-condition: return an array of movies that are stored in dictionary order by their titles
	public IMovie[] ToArray()
	{
		ResetIndex(ref i);
		IMovie[] list = new IMovie[Number];
		InOrderTraverse(root, list);
		return list;
	}

	//private function created to perform recursion In-Order Traversal
	//to set each each element in the array 
	//Used in ToArray() function
	private void InOrderTraverse(BTreeNode root, IMovie[] list)
	{
		if (root != null)
		{
			InOrderTraverse(root.LChild, list);
			list[i] = root.Movie;	
			ChangingIndex(ref i);
			InOrderTraverse(root.RChild, list);
		}
	}

	//reference method created to increase index reference to store in array 
	//in TOArray() function
	void ChangingIndex(ref int i)
	{	
		i++;
	}

	//reference method created to reset index reference to start the array 
	//in TOArray() function
	void ResetIndex(ref int i)
    {
		i = 0;
    }



	// Clear this movie collection
	// Pre-condotion: nil
	// Post-condition: all the movies have been removed from this movie collection 
	public void Clear()
	{
		root = null;
		count = 0;
	}
}





