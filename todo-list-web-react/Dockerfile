FROM node:22-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 3000

RUN apk add --no-cache bash curl

RUN chmod +x /app/infra/wait-for-healthy-api.sh
ENTRYPOINT [ "/app/infra/wait-for-healthy-api.sh" ]
CMD ["npm", "run", "dev"]