<template>
<div>
<AddUser :Id="Id" :Name="Name" :UserId="UserId"  @Add-Click="AddUser" @Update-Click="UpdateUser"></AddUser>
<UserList :users="user" @Edit-Click="EditUser" @Delete-Click="DeleteUser"></UserList>
</div>
</template>
<script>
import AddUser from "./components/AddUser.vue";
import UserList from "./components/UserList.vue";
export default {
    components: {AddUser, UserList},
    data(){
        return{
          Id: "",
          user:[],
          Name: "",
          UserId:"",
        };
    },
    mounted(){
      this.loadUser();
    },
    methods: {
      ClearData(){
        this.Id="";
        this.Name="";
        this.UserId="";
      },
      loadUser() {
      fetch("/api/Notepad", {
        method: "GET",
      })
        .then((response) => response.json())
        .then((data) => {
          this.user = data;
        })
        .catch(() =>
          console.log("Can’t access " + url + " response. Blocked by browser?")
        );
    },
    EditUser(user) {
      this.Id = user.id.toString();
      this.Name = user.name;
      this.UserId = user.userId.toString();
    },
    DeleteUser(user){
      fetch("/api/Notepad/" + user.id, {
        method: "DELETE",
      }).then(() => {
        this.loadUser();
      });
    },
    AddUser(Name,UserId)
    {
      fetch("/api/Notepad", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name: Name,
        userId: parseInt(UserId)
        }),
      }).then((response) => {
        this.loadUser();
        this.ClearData();
      });

    },
     UpdateUser(Id,Name,UserId) {
      fetch("/api/Notepad/" + parseInt(Id), {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          id: parseInt(Id),
          name: Name,
          userId: parseInt(UserId),
        }),
      })
      .then((response) => {
        this.loadUser();
        this.ClearData();
      });
    },        
    },
}
</script>