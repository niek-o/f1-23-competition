<script setup lang="ts">

</script>

<template>
    <!DOCTYPE html>
    <html>
      <head>
        <title>Leader Board</title>
      </head>
      <body>
        <table>
          <tr>
            <th>Username</th>
            <th>Time</th>
            <th>Track</th>
            <th>Date</th>
          </tr>
          <tr>
            <td>Mart</td>
            <td>01:12.573</td>
            <td>Zandvoort</td>
            <td>13/12/2023</td>
          </tr>
          <tr>
            <td>Jay</td>
            <td>01:22.437</td>
            <td>Spa</td>
            <td>07/11/2023</td>
          </tr>
          <tr>
            <td>Niek</td>
            <td>01:37.569</td>
            <td>Monza</td>
            <td>10/09/2023</td>
          </tr>
        </table>
      </body>
    </html>
</template>

<style scoped>
  td:nth-child(even){
    background-color: #130347;
  }
  th {
    text-align: center;
}
td {
    text-align: left;
}
table, th, td {
  width: 500px;
  border: rgb(112, 112, 112);
  border-style: solid;
  border-collapse: collapse;
}
table {
  border-radius: 50%;
}
</style>