<Query Kind="Expression" />

//CQRS = Command Model, Query Model, Responsibility, Segregating
//Comands used in the data base
//Query data is what comes out on the form 
//
//Google mark down tutorial and complete the hour long tutorial on mark down


//command buttons for playlist management image
//command:
	//Add Track
		//Data needed to add track = playlistname and track ID
			//no class is needed 

	//Remove Track
		//Data needed to remove track = playlist name, List<>
		//No Class Needed
	//Move Track
		//Data needed to move = PlayList Name 
			//Class is required
			
				//public class ReorgTrackItem{	
					//public  int TrackID
					//public int CurrentTrackNumber
					//public ReorgTrackNumber
					//}



//***refer to playlist management Image***
	//Data we will need to create form 
//public class SongItem {
		//public string song {get;set;}
		//public string album{get;set}
		//public string artist{get;set;}
		//public double Length{get;set;}
		//public double Price{get;set;}
		//public int TrackID[get;set}			***TrackID will be hidden behind the add song button.
		//	}
		
		
		//Check box is input(comes from the user)
		//Track number is output (comes from database)
	//public class PlayListItem {
		//public int TrackNumber{get;set;}
		//public string SongName{get;set;}
		//public double Length{get;set;}
		//public int TrackID{get;set;}		***TrackID is hidden behind the check box in this class
		
		

		
		