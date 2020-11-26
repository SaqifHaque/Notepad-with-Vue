<template>
<div>
  <table style="width:100%">
  <thead>
    <th>Name</th>
    <th>User Id</th>
    <th>Actions</th>
  </thead>
  <tr v-for="u in users">
    <td>{{u.name}}</td>
    <td>{{u.userId}}</td>
    <td><button v-on:click="Edit(u)" type="button">Edit</button>
    <button v-on:click="Remove(u)" type="button">Delete</button></td>  
  </tr>
</table>
</div>
</template>
<script>
export default {
    props:["users"],
    methods: {
      Edit(user){
        this.$emit("Edit-Click",user);

      },
      Remove(user){
        this.$emit("Delete-Click",user);
      },
       
    },
}
</script>