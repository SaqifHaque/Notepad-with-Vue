<template>
<div>
<form
  @click="checkForm"
>
    <input v-model="Name" type="text" placeholder="Name">
    <input v-model="UserId" type="text" placeholder="User Id">
    <button v-on:click="AddClick()" type="button" class="btn">Add</button>
    <button v-on:click="UpdateClick()" type="button" class="btn">Update</button>
</form>
<p v-if="errors.length">
    <b>Please correct the following error(s):</b>
    <ul>
      <li v-for="error in errors">{{ error }}</li>
    </ul>
  </p>
</div>
</template>
<script>
export default {
    props:["Id","Name","UserId"],
    data() {
    return {
      errors: [],
    };
  },
    methods: {
        checkForm: function (e) {
        let isnum = /^\d+$/.test(this.UserId);
        this.errors = [];
        console.log(isnum);
      if (this.Name && this.UserId) {
        return true;
      }
      else{
      if (this.Name == "") {
        this.errors.push('Name required.');
      }
      if(this.UserId == "" || isnum){
          this.errors.push('Provide Valid userId');

      }
      e.preventDefault();
      }
      e.preventDefault();
    },
    AddClick(){
        this.$emit("Add-Click",this.Name,this.UserId);
    },
    UpdateClick(){
        this.$emit("Update-Click",this.Id,this.Name,this.UserId);
    }
        
    },
}
</script>