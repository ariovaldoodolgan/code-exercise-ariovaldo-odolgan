import { API_URL } from "@/constants/env";
import { PalindromeResult } from "@/interfaces/PalindromeResult";

const postPalindrome = async (body: any): Promise<PalindromeResult> =>
  await fetch(`${API_URL}/palindrome`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
    },
    body: JSON.stringify(body),
  }).then((response) => response.json());

const getAll = async (): Promise<PalindromeResult[]> =>
  await fetch(`${API_URL}/palindrome`)
    .then((response) => {
      if (response.status === 200) {
        return response.json();
      }
      return [];
    })
    .catch((error) => {
      console.log(error);
    });

export const PalindromeService = {
  getAll,
  postPalindrome,
};
