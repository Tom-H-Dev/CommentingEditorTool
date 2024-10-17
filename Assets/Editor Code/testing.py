

import google.generativeai as genai
import os

genai.configure(api_key=os.environ["AIzaSyColxW4aPKMYYfLS8vB00vAKVzfSB2iL_g"])
model = genai.GenerativeModel("gemini-1.5-flash")
response = model.generate_content("Write a story about a magic backpack.")
print(response.text)