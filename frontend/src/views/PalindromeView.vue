<template>
  <section id="palindrome">
    <h1>Palindrome</h1>
    <span>Verify if your string is a palindrome</span>

    <div class="form">
      <input
        v-model="inputText"
        class="palindromeInput"
        type="text"
        placeholder="Please enter text"
      />
      <button id="primary-button" @click="validateInput">
        Validate string
      </button>
    </div>

    <div class="table">
      <var-table>
        <thead>
          <tr>
            <th class="header-result">Results</th>
            <th class="header-palindrome">Is Palindrome?</th>
            <th class="header-palindrome">Create At</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in resultList" :key="index">
            <td>{{ item.input }}</td>
            <td>
              {{ item.isPalindrome ? "Is a palindrome" : "Not a palindrome" }}
            </td>
            <td>{{ item.createAt }}</td>
          </tr>
        </tbody>
      </var-table>
    </div>
  </section>
</template>

<script lang="ts">
import { ref, computed, onBeforeMount } from "vue";
import { palindromeStore } from "../store/palindrome";

export default {
  setup() {
    const store = palindromeStore();
    const inputText = ref("");
    const resultList = computed(() => store.listOfValidationResults);

    onBeforeMount(() => {
      store.getListOfValidationResults;
    });

    function validateInput() {
      store.validateInputText(inputText.value);
    }

    return {
      validateInput,
      inputText,
      resultList,
    };
  },
};
</script>
