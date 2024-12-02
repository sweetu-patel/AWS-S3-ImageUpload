# AWS-S3-ImageUpload

A C# application for uploading images to AWS S3. This project demonstrates how to configure and use AWS SDK in a .NET environment for efficient image storage on Amazon's Simple Storage Service (S3).

## Features

- Upload images to AWS S3 buckets.
- Configurable AWS credentials and bucket settings.
- Simple and intuitive C# implementation.

## Prerequisites

Before running this application, ensure the following:

1. **AWS Account**: Create an account on [AWS](https://aws.amazon.com/).
2. **AWS S3 Bucket**: Set up an S3 bucket in your AWS account.
3. **AWS IAM User**:
    - Create an IAM user with programmatic access.
    - Attach the necessary permissions (e.g., `AmazonS3FullAccess`).
4. **AWS SDK for .NET**: Install the AWS SDK for .NET via NuGet.

## Getting Started

1. Clone this repository:
    ```bash
    git clone https://github.com/sweetu-patel/AWS-S3-ImageUpload.git
    ```
2. Open the solution file `AWS S3 ImageUpload.sln` in Visual Studio.
3. Configure AWS settings:
    - Set your AWS Access Key and Secret Key.
    - Specify the bucket name and region in the application configuration.

4. Build and run the project.

## File Structure

- `.gitignore`: Specifies files and folders to exclude from version control.
- `AWS S3 ImageUpload.sln`: The solution file for the project.
- Project files and dependencies are contained in the main directory.

## Usage

1. Run the application.
2. Select an image file to upload.
3. The application will upload the image to the configured S3 bucket and return a success message or log an error if the upload fails.

## Technologies Used

- **C#**: The programming language for the application.
- **AWS S3**: Amazon's Simple Storage Service for cloud storage.
- **AWS SDK for .NET**: The SDK for interacting with AWS services.

## License

This project is open source. Feel free to modify and use it in your projects.

## Support

If you have any questions or encounter any issues, please open an [issue](https://github.com/sweetu-patel/AWS-S3-ImageUpload/issues).

---

### Author

Developed by [Sweetu Patel](https://github.com/sweetu-patel).
