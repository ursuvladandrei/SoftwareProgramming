FROM node:22
WORKDIR /usr/src/fantastic-app
COPY package.json package-lock.json index.js /usr/src/fantastic-app/
RUN npm install
CMD ["node", "index.js"]
EXPOSE 8080