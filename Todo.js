var persioninfo = document.querySelector('.todo-info')

//api get persion
const get ="https://localhost:7092/api/Persions"


//khoi tao ham hien thi danh sach entities
function getPersion(url,callback)
{
  const data=fetch(url)
  .then(response => response.json())
  .then(data => {
      
        
     const html =  data.map((item)=>{
      
            return `
            <ul id="${item.persionCode}" class="info-persion">
            <li>Code:${item.persionCode}</li>
            <li>Name:${item.persionName} 
            <li>Gender:${item.gender == "1" ? "Nam" : "Nu"}</li>
            <li><button onclick="checkcode('${item.persionCode}')" class="btn delete">Delete</button>
            <button onclick="editClick1('${item.persionCode}')" class="btn edit ${item.persionCode}">Edit</button></li>
            </ul>
   
            `
        
        })
        
        persioninfo.innerHTML =html.join("")
      })
      .then(callback)
}

//hien thi danh sach tat ca cac enities
getPersion(get)





//delete 1 nguoi
  const deleteP = "https://localhost:7092/api/Persions/"
  function checkcode(code){

    fetch('https://localhost:7092/api/Persions' + '/'+ code, {
      method: 'DELETE',
      headers: {
        'Content-type': 'application/json'

       },
    })
    .then(function (){
      var id = document.getElementById(code)
      id.remove();

    })
    
    
  }

  //hien thi bang them nguoi moi
var displaytask = document.getElementById("task")
const CreatePersion =()=>{
  displaytask.style.display = "block"
}

//api create a persion

var posturl ='https://localhost:7092/api/Persions'



//call API POST
function postPersion(data){
  const response = fetch('https://localhost:7092/api/Persions',{
    method: 'POST', 
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
    
  }).then(()=>getPersion(get))
}


// Lưu người mới vừa tạo
const createSave=()=>{
  const messerro = {
    mes:"Khong duoc bo trong"
  }
  var inputCode = document.getElementById("inputCode").value
  var inputName = document.getElementById("inputName").value
  var inputBrithday = document.getElementById("inputBrithday").value
  var inputGender = document.getElementById("inputGender").value
  var inputAddress = document.getElementById("inputAddress").value
  

  if(inputCode!='' && inputName !='' && inputBrithday !=''&&inputAddress !='')
  {
    var data = {
      persionCode:inputCode,
      persionName:inputName,
      birthday:inputBrithday,
      gender:inputGender,
      adress:inputAddress
    }
    postPersion(data)
    displaytask.style.display = "none"
  }else{
    alert(messerro.mes)
  }

}


//Click edit

const editClick1 =(code)=>{
  var ula = document.getElementById(code)
  
  
  var inputnameE = document.createElement("li")
  var inputgenderE = document.createElement("li")
  var divsave = document.createElement("div")
  inputnameE.innerHTML = `Name:<input id="idNameEdit" type="text" class="input-NameEdit"></input>`
  inputgenderE.innerHTML = `Gender:<input id="idGenderEdit" class="input-GenderEdit" type="text"></input>`
  divsave.innerHTML=`<button onclick="UpdatePersion('${code}')" class="btn edit">Save</button>`
  var btnedit = document.querySelector(`.${code}`)
  console.log(btnedit)
  btnedit.replaceWith(divsave)
  ula.children[1].replaceWith(inputnameE)
  ula.children[2].replaceWith(inputgenderE)

}

/// api put
const EditPersion = (code,dataupdate)=>{
  fetch('https://localhost:7092/api/Persions'+'/'+code, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(dataupdate)
  })
  .then(()=>getPersion(get))
}

/// Click update
const UpdatePersion = (code)=>{

  var inputNameEditvalue= document.getElementById('idNameEdit').value
  var inputGenderEditvalue= document.getElementById('idGenderEdit').value

    dataEdit={
      persionCode:code,
      persionName:inputNameEditvalue,
      birthday:'',
      gender:inputGenderEditvalue,
      adress:''
    }

    EditPersion(code,dataEdit)
}