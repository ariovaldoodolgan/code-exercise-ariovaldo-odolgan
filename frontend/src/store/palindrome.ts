import { PalindromeResult } from "@/interfaces/PalindromeResult";
import { PalindromeService } from "@/services/palindrome.services";
import { defineStore } from "pinia";

export const palindromeStore = defineStore({
  id: "palindrome",
  state: () => {
    return {
      listOfValidationResults: [] as PalindromeResult[],
    };
  },
  getters: {
    getListOfValidationResults: (state) => {
      if (state.listOfValidationResults?.length === 0) {
        PalindromeService.getAll().then(
          (resp: PalindromeResult[]) => (state.listOfValidationResults = resp)
        );
      }
      return state.listOfValidationResults;
    },
  },
  actions: {
    validateInputText(inputText: string) {
      const body = {
        value: inputText,
      };

      PalindromeService.postPalindrome(body).then((resp: PalindromeResult) => {
        this.listOfValidationResults.unshift(resp);
      });
    },
  },
});
