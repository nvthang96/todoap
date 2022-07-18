var persioninfo = document.querySelector('.todo-info')
console.log(persioninfo)

const checkGender = (gender)=>
{
    if(check=="1")
    {
        return "Nam"  
      }else return "Nu"
}
const get ="https://localhost:7092/api/Persions"

const listpersion = []
const deleteP = "https://localhost:7092/api/Persions/PS1"
const data = fetch(get)
  .then(response => response.json())
  .then(data => {
      
        
        persioninfo.innerHTML=  data.map(item=>{
        
            return `
            <ul class="info-persion">
            <div>   
            <li>Code:${item.persionCode}</li>
            <li>Name:${item.persionName}</li> 
            <li>Gender:${item.gender == "1" ? "Nam" : "Nu"}</li>
            </div>
            <div class="btn">
            <button onclick="" class="btn-edit">Edit</button> 
            <button  class="btn-edit">Delete</button> 
            </div>
            </ul>
   
            `
            
        })
 
      
    
  })
 ;
