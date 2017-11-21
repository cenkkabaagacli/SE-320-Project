
 private var move:float = 20;
 private var stop:boolean = false;	
 private var blend:float;
 private var delay:float = 0;
 var AddRunSpeed:float = 1;
 var AddWalkSpeed:float = 1;
 private var hasAniComp:boolean = false;

function Start ()    
{
	if ( null != GetComponent(Animation) )
	{
		hasAniComp = true;
	}
}
            
function Move ()
{ 
	var speed:float=0.0f;
	var add:int=0;
	
	if ( hasAniComp == true )
	{	
		if ( Input.GetKey(KeyCode.UpArrow) )
			    {  	
			    	move *= 1.015F;
			    	
			    	if ( move>250 && CheckAniClip( "run" )==true )
			    		{
			    			{
				    			GetComponent.<Animation>().CrossFade("run");
				    			add = 20*AddRunSpeed;
			    			}
			    		}
			    	else
			    		{
			    			GetComponent.<Animation>().Play("walk");
			    			add = 5*AddWalkSpeed;
			    		}
			    			    	
			        speed = Time.deltaTime*add;
			        
			        transform.Translate( 0,0,speed );
			    }

			        
	    if ( Input.GetKeyUp(KeyCode.UpArrow))
	    	{
				if ( GetComponent.<Animation>().IsPlaying("walk"))
					{	GetComponent.<Animation>().CrossFade("idle01",0.3); }
				if ( GetComponent.<Animation>().IsPlaying("run"))
					{	
						GetComponent.<Animation>().CrossFade("idle01",0.5);
						stop = true;
					}	
				move = 20;
			}
					
		if (stop == true)
			{	
				//var max:float = Time.deltaTime*40;
				var max:float = Time.deltaTime*20*AddRunSpeed;
				blend = Mathf.Lerp(max,0,delay);
				
				if ( blend > 0 )
				{	
					transform.Translate( 0,0,blend );
					delay += 0.025f; 
				}	
				else 
				{	
					stop = false;
					delay = 0.0f;
				}
			}
	}
	else
	{
		if ( Input.GetKey(KeyCode.UpArrow) )
			    {  	
			       	add = 5*AddWalkSpeed;
			        speed = Time.deltaTime*add;
			        transform.Translate( 0,0,speed );
			    }
	}
}

function CheckAniClip ( clipname )
{	
	if( this.GetComponent.<Animation>().GetClip(clipname) == null ) 
		return false;
	else if ( this.GetComponent.<Animation>().GetClip(clipname) != null ) 
		return true;
	
	return false;
}

function Update () 
	{
		//print ("again");
		
		Move();
			
		if ( hasAniComp == true )
		{	
			if (Input.GetKey(KeyCode.V))
				{	
					if ( CheckAniClip( "damage away" ) == false ) return;
					
					GetComponent.<Animation>().CrossFade("damage away",0.2);
					GetComponent.<Animation>().CrossFadeQueued("idle01");
				} 
				
			if (Input.GetKey(KeyCode.C))
			{	
				if ( CheckAniClip( "dead away" ) == false ) return;
				
				GetComponent.<Animation>().CrossFade("dead away",0.2);
	//			animation.CrossFadeQueued("idle01",0.5);
			} 
			
			if (Input.GetKey(KeyCode.E))
				{	
					if ( CheckAniClip( "attack03" ) == false ) return;
					
					GetComponent.<Animation>().CrossFade("attack03",0.2);
					GetComponent.<Animation>().CrossFadeQueued("idle01");
				} 
			   
			if (Input.GetKey(KeyCode.Q))
				{	
					if ( CheckAniClip( "attack01" ) == false ) return;
					
					GetComponent.<Animation>().CrossFade("attack01",0.2);
					GetComponent.<Animation>().CrossFadeQueued("idle01");
				}
				
			if (Input.GetKey(KeyCode.W))
				{	
					if ( CheckAniClip( "attack02" ) == false ) return;
					
					GetComponent.<Animation>().CrossFade("attack02",0.2);
					GetComponent.<Animation>().CrossFadeQueued("idle01");
				}
				
			if (Input.GetKey(KeyCode.A))
				{	
					if ( CheckAniClip( "drop down" ) == false ) return;
					
					GetComponent.<Animation>().CrossFade("drop down",0.2);
					//animation.CrossFadeQueued("idle1");
				}
		
			if (Input.GetKey(KeyCode.Z))
				{	
					if ( CheckAniClip( "sit up" ) == false ) return;
				
					GetComponent.<Animation>().CrossFade("sit up",0.2);
					GetComponent.<Animation>().CrossFadeQueued("idle01");
				}
			
			if (Input.GetKey(KeyCode.S))
				{	
					if ( CheckAniClip( "damage" ) == false ) return;
					
					GetComponent.<Animation>().CrossFade("damage",0.1);
					GetComponent.<Animation>().CrossFadeQueued("idle01");			
				}
				
			if (Input.GetKey(KeyCode.X))
				{	
					if ( CheckAniClip( "dead" ) == false ) return;
								
					GetComponent.<Animation>().CrossFade("dead",0.1);
					//animation.CrossFadeQueued("idle01");			
				}			
				
			if (Input.GetKey(KeyCode.D))
				{	
					if ( CheckAniClip( "idle02" ) == false ) return;
				
					GetComponent.<Animation>().CrossFade("idle02",0.1);
					GetComponent.<Animation>().CrossFadeQueued("idle01");			
				}			
		}
						
			if ( Input.GetKey(KeyCode.LeftArrow))
				{
					transform.Rotate( 0,Time.deltaTime*-100,0);
				}
			
			if (Input.GetKey(KeyCode.RightArrow))
				{
					transform.Rotate(0,Time.deltaTime*100,0);
				}
	}
	
