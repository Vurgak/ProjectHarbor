FROM node:20-alpine
WORKDIR /app
COPY package.json ./
RUN npm install

COPY . .
RUN npm run build

FROM nginx:1.25-alpine
COPY --from=builder /app/build /usr/share/nginx/html
COPY nginx/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]
